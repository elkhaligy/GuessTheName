using ClientApp.Presenters;
using ClientApp.Views;
using Shared;
using System.Data;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Windows.Forms;
/*
 * Each request sent has a response back from server
 * This response is handled by resolveResponse() method
 */
namespace ClientApp
{
    public partial class ClientForm : Form
    {
        public Player Player { get; set; }
        private List<GameRoom> roomsListFromServerToDisplay = new List<GameRoom>();
        GameForm frm;

        public ClientForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            /*
             * Create a tcp client
             * Use this tcp client to connect to a remote server
             * On successful connection create a new thread for that tcp client to listen for server responses
             * Start the thread
             */

            /* 
             * Create a new player object
             * Populate this object data with the username label
             * Set the score to zero
             * Set its tcp client to the current tcp client
             */

            /* 
             * Send the server a request that has the username of this player
             * Hide the login panel
             */

            /*
             * Send the server a request to get the list of the rooms currently available
             * Update the UI elements with the returned rooms list
             */

            /*
             * Show the room list panel
             * Update the room list panel with the retrieved rooms
             */

            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 50000);
            new Thread(() => listenForMessages()) { IsBackground = true }.Start();

            Player = new Player { tcpClient = tcpClient, Name = userNameTextBox.Text, Score = 0 };

            Command loggingRequest = new Command(CommandTypes.Login, Player);
            sendCommand(loggingRequest);
            loginPanel.Hide();

            Command command = new Command(CommandTypes.GetRooms, new GetRoomCommandPayload());
            sendCommand(command); // Request sent, Response handling is done on resolveResponse() method
        }

        private void sendCommand(Command command)
        {
            var stream = Player.tcpClient.GetStream();
            var streamWriter = new StreamWriter(stream) { AutoFlush = true };
            var json = JsonSerializer.Serialize(command);
            streamWriter.WriteLine(json);
        }

        private void listenForMessages()
        {
            var stream = Player.tcpClient.GetStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);

            while (true)
            {
                string response = streamReader.ReadLine();
                resolveResponse(response);
            }
        }

        public void resolveResponse(string response)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(resolveResponse), response);
                return;
            }

            Command command = JsonSerializer.Deserialize<Command>(response);
            switch (command.CommandType)
            {
                case CommandTypes.RoomCreated:
                    GameRoom receivedRoom = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                    Player.CurrentRoom = receivedRoom.RoomId;
                    Player.IsRoomOwner = true;
                    roomsListPanel.Hide();
                    roomCreationPanel.Hide();
                    lobbyPanel.Show();
                    ownerNameLabel.Text = Player.Name + " (Me)";
                    break;

                case CommandTypes.RoomsList:
                    roomsListFromServerToDisplay = JsonSerializer.Deserialize<List<GameRoom>>(command.Payload.ToString());
                    roomsListPanel.Show();
                    updateRoomsListGUI();
                    break;

                case CommandTypes.JoinRoom:
                    GameRoom joinedRoom = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                    //MessageBox.Show(command.Payload.ToString());
                    GameRoom gameRoom = roomsListFromServerToDisplay.Find(room => room.RoomId == joinedRoom.RoomId);
                    gameRoom.Guest = joinedRoom.Guest;
                    Player.CurrentRoom = joinedRoom.RoomId;
                    Player.IsRoomOwner = false;
                    roomsListPanel.Hide();
                    lobbyPanel.Show();
                    ownerNameLabel.Text = joinedRoom.Owner;
                    guestNameLabel.Text = Player.Name + " (Me)";
                    break;
                case CommandTypes.StartGame:
                    Command startGame = new Command(CommandTypes.StartGame, null);
                    break;

                case CommandTypes.GameStarted:
                    if(command.Payload == null)
                    {
                        MessageBox.Show("Wait till another play join the room");
                    }
                    else
                    {
                        GamePresenter presenter = JsonSerializer.Deserialize<GamePresenter>(command.Payload.ToString());
                        Thread gameThread = new Thread(() => OnGameStart(presenter));
                        gameThread.Start();
                    }
                    break;

                case CommandTypes.RoomUpdated:
                    HashSet<char> revealedLetters = JsonSerializer.Deserialize<HashSet<char>>(command.Payload.ToString());
                    if (frm != null)
                    {
                        frm.presenter.guessedLetters = revealedLetters;
                        frm.viewRevealedLetters(); // Update the UI with the revealed letters
                    }
                    break;

                default:
                    break;
            }
        }

        private void OnGameStart(GamePresenter presenter)
        {
            frm = new GameForm(presenter, Player.Name);
            frm.Size = this.Size;
            frm.Location = this.Location;
            frm.OnReveal += async (args, revealed) =>
            {
                Command updateThePlayer = new Command(CommandTypes.RoomUpdated, revealed);
                sendCommand(updateThePlayer);
            };
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    this.Hide();
                    frm.Show();
                    frm.FormClosed += (args, e) => this.Close();
                });
                return;
            }
        }


        public void updateRoomsListGUI()
        {
            roomsListFlowLayout.Controls.Clear();
            foreach (var receivedRoom in roomsListFromServerToDisplay)
            {
                AddRoomPanel(roomName: receivedRoom.RoomId, creator: receivedRoom.Owner, receivedRoom.Guest, status: receivedRoom.State.ToString());
            }
        }

        private void refreshRoomsButton_Click(object sender, EventArgs e)
        {
            Command command = new Command(CommandTypes.GetRooms, new GetRoomCommandPayload());
            sendCommand(command);
        }

        private void userNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                loginButton_Click(sender, e);
            }
        }

        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            roomsListPanel.Hide();
            tryCategoriesComboBox.Items.Add("Animals");
            tryCategoriesComboBox.Items.Add("Countries");
            tryCategoriesComboBox.Items.Add("Food");
            tryCategoriesComboBox.SelectedIndex = 0;
            roomCreationPanel.Show();
        }

        private void confirmCreationButton_Click(object sender, EventArgs e)
        {
            string takenRoomName = tryRoomNameTextBox.Text;
            string takenRoomCat = tryCategoriesComboBox.Text;
            GameRoom gameRoom = new GameRoom { RoomId = takenRoomName, Owner = Player.Name, Category = takenRoomCat };
            Command createRoomRequest = new Command(CommandTypes.CreateRoom, gameRoom);
            sendCommand(createRoomRequest);
        }
        private void joinRoomButton_Click(string roomName)
        {
            //MessageBox.Show($"{roomName}");
            GameRoom gameRoom = new GameRoom { RoomId = roomName, Guest = Player.Name };
            Command joinRoomRequest = new Command(CommandTypes.JoinRoom, gameRoom);
            sendCommand(joinRoomRequest);
            roomsListPanel.Hide();
            lobbyPanel.Show();
        }

        private void AddRoomPanel(string roomName, string creator, string otherPlayer, string status)
        {
            // Create the panel
            Panel roomPanel = new Panel
            {
                Size = new Size(250, 130),
                BackColor = Color.GhostWhite,

                BorderStyle = BorderStyle.FixedSingle
            };

            // Room Name Label
            Label nameLabel = new Label
            {
                Text = $"Room: {roomName}",
                Location = new Point(10, 10),
                AutoSize = true
            };
            roomPanel.Controls.Add(nameLabel);

            // Room Creator Label
            Label creatorLabel = new Label
            {
                Text = $"Creator: {creator}",
                Location = new Point(10, 30),
                AutoSize = true
            };
            roomPanel.Controls.Add(creatorLabel);

            // Other Player Label
            Label playerLabel = new Label
            {
                Text = $"Other Player: {otherPlayer}",
                Location = new Point(10, 50),
                AutoSize = true
            };
            roomPanel.Controls.Add(playerLabel);

            // Room Status Label
            Label statusLabel = new Label
            {
                Text = $"Status: {status}",
                Location = new Point(10, 70),
                AutoSize = true
            };
            roomPanel.Controls.Add(statusLabel);

            // Join Button
            Button joinButton = new Button
            {
                Text = "Join",
                Size = new Size(100, 30),
                Location = new Point(10, 90)
            };
            joinButton.Click += (s, e) => { joinRoomButton_Click(roomName); };
            roomPanel.Controls.Add(joinButton);

            // Spectate Button
            Button spectateButton = new Button
            {
                Text = "Spectate",
                Size = new Size(100, 30),
                Location = new Point(130, 90)
            };
            spectateButton.Click += (s, e) => MessageBox.Show($"Spectating {roomName}...");
            roomPanel.Controls.Add(spectateButton);

            // Add the panel to FlowLayoutPanel (Assuming you have one)
            roomsListFlowLayout.Controls.Add(roomPanel);
            otherPlayer = otherPlayer ?? "";
            if (creator.Length > 0 && otherPlayer.Length > 0)
            {
                joinButton.Enabled = false;
            }
            roomPanel.Controls.Add(joinButton);
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {

            Command command = new Command(CommandTypes.StartGame, new GetRoomCommandPayload());
            sendCommand(command);
        }
    }
}
