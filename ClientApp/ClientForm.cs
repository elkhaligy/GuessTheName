using Shared;
using System.Data;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
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
                    //MessageBox.Show("Room Created Successfully!")
                    roomsListPanel.Hide();
                    roomCreationPanel.Hide();
                    lobbyPanel.Show();
                    updateLobbyRoomGUI();
                    break;
                case CommandTypes.RoomsList:
                    roomsListFromServerToDisplay = JsonSerializer.Deserialize<List<GameRoom>>(command.Payload.ToString());
                    roomsListPanel.Show();
                    updateRoomsListGUI();
                   
                    break;
                case CommandTypes.RoomUpdated:
                    break;
                case CommandTypes.StartGame:
                    /*
                     * 
                     * 
                     * 
                     */
                    break;
                default:
                    break;
            }
        }

        public void updateRoomsListGUI()
        {
            roomsListFlowLayout.Controls.Clear();
            foreach (var receivedRoom in roomsListFromServerToDisplay)
            {
                //RoomUserControl roomControl = new RoomUserControl(this, receivedRoom.Owner, receivedRoom.RoomId, receivedRoom.Category);
                //roomsListFlowLayout.Controls.Add(roomControl);
                AddRoomPanel(roomName: receivedRoom.RoomId, creator: receivedRoom.Owner, status: receivedRoom.State.ToString());
            }
        }

        public void updateLobbyRoomGUI()
        {
            if (Player.IsRoomOwner)
            {
                ownerNameLabel.Text = Player.Name;
            }
            else
            {
                guestNameLabel.Text = Player.Name;
            }
        }
        public void JoinRoomButton_Click()
        {
            MessageBox.Show("Show");
            // What I need about this?
            // I only need room name
            //string roomNameToJoin = 
        }
        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            string roomName;
            string roomCategory;

            roomsListPanel.Hide();

            tryCategoriesComboBox.Items.Add("Countries");
            tryCategoriesComboBox.Items.Add("Banana");
            tryCategoriesComboBox.Items.Add("Orange");
            tryCategoriesComboBox.SelectedIndex = 0;
            roomCreationPanel.Show();
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

        private void confirmCreationButton_Click(object sender, EventArgs e)
        {
            string takenRoomName = tryRoomNameTextBox.Text;
            string takenRoomCat = tryCategoriesComboBox.Text;
            GameRoom gameRoom = new GameRoom { RoomId = takenRoomName, Owner = Player.Name, Category = takenRoomCat };
            Command createRoomRequest = new Command(CommandTypes.CreateRoom, gameRoom);
            sendCommand(createRoomRequest);

        }


        private void AddRoomPanel(string roomName, string creator, string status)
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
                Location = new Point(10, 35),
                AutoSize = true
            };
            roomPanel.Controls.Add(creatorLabel);

            // Room Status Label
            Label statusLabel = new Label
            {
                Text = $"Status: {status}",
                Location = new Point(10, 60),
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
            joinButton.Click += (s, e) => MessageBox.Show($"Joining {roomName}...");
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
        }
    }

}
