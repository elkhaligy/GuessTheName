using Shared;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
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
        private GameRoom currentRoom;


        // Socket related fields
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        string secretWord;

        public ClientForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            StartGameButton.Enabled = false;
            guestNameLabel.Text = "";
            ownerNameLabel.Text = "";
        }
        public string getSecretWord(string category)
        {
            // Get the base directory of execution
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Navigate up 3 levels and then to "Shared\Data\Animal.txt"
            string relativePath = Path.Combine(basePath, @$"..\..\..\..\Shared\Data\{category}.txt");

            // Get the absolute path
            string fullPath = Path.GetFullPath(relativePath);

            Random random = new Random();
            // Check if file exists
            if (File.Exists(fullPath))
            {
                List<string> randomNames = File.ReadAllLines(fullPath).ToList();
                int randomIndex = random.Next(randomNames.Count);
                return randomNames[randomIndex];
            }
            return null;
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
            this.Text = $"Guess the Name Game (Playing as {Player.Name})";

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
            GameRoom receivedRoom;

            switch (command.CommandType)
            {
                case CommandTypes.RoomCreated:
                    receivedRoom = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                    currentRoom = receivedRoom;
                    Player.CurrentRoom = receivedRoom.RoomId;
                    Player.IsRoomOwner = true;
                    roomsListPanel.Hide();
                    roomCreationPanel.Hide();
                    lobbyPanel.Show();
                    guestReadyCheckbox.Enabled = false;
                    ownerNameLabel.Text = Player.Name + " (Me)";
                    label16.Text = receivedRoom.RoomId;
                    label13.Text = receivedRoom.Category;
                    break;

                case CommandTypes.RoomsList:
                    roomsListFromServerToDisplay = JsonSerializer.Deserialize<List<GameRoom>>(command.Payload.ToString());
                    roomsListPanel.Show();
                    updateRoomsListGUI();
                    break;

                case CommandTypes.RoomUpdated:
                    receivedRoom = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                    currentRoom = receivedRoom;
                    if (Player.IsRoomOwner)
                        guestNameLabel.Text = receivedRoom.Guest;
                    guestReadyCheckbox.Checked = receivedRoom.IsGuestReady;
                    ownerReadyCheckbox.Checked = receivedRoom.IsOwnerReady;
                    if (Player.IsRoomOwner && receivedRoom.IsGuestReady && receivedRoom.IsOwnerReady)
                    {
                        StartGameButton.Enabled = true;
                    }
                    break;

                case CommandTypes.JoinRoom:
                    GameRoom joinedRoom = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                    currentRoom = joinedRoom;
                    secretWord = joinedRoom.secretWord;

                    GameRoom gameRoom = roomsListFromServerToDisplay.Find(room => room.RoomId == joinedRoom.RoomId);
                    gameRoom.Guest = joinedRoom.Guest;
                    Player.CurrentRoom = joinedRoom.RoomId;
                    Player.IsRoomOwner = false;
                    roomsListPanel.Hide();
                    lobbyPanel.Show();
                    ownerNameLabel.Text = joinedRoom.Owner;
                    guestNameLabel.Text = Player.Name + " (Me)";
                    ownerReadyCheckbox.Enabled = false;
                    StartGameButton.Hide();


                    break;

                case CommandTypes.StartGame:
                    currentRoom = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                    secretWord = currentRoom.secretWord;
                    int textBoxWidth = 50;
                    int spacing = 10;
                    int totalWidth = (secretWord.Length * (textBoxWidth + spacing)) - spacing;

                    // Calculate starting X position to center align
                    int startX = (gamePanel.Width - totalWidth) / 2;
                    int startY = 200; // Keep Y position fixed

                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        TextBox textBox = new TextBox
                        {
                            Name = $"txtBox{i + 1}",   // Unique name
                            Width = textBoxWidth,
                            Height = 100,
                            BackColor = Color.Black,
                            ForeColor = Color.White,
                            Font = new Font("Arial", 15),
                            Location = new Point(startX + i * (textBoxWidth + spacing), startY) // Adjusted positioning
                        };

                        gamePanel.Controls.Add(textBox);
                    }

                    if (Player.IsRoomOwner)
                    {
                        //MessageBox.Show($"Game Started Me {Player.Name} vs {currentRoom.Guest}\n in Room {currentRoom.RoomId} with category {currentRoom.Category}");
                        lobbyPanel.Hide();
                        gamePanel.Show();
                        label10.Text = currentRoom.Guest;
                        label11.Text = currentRoom.Owner;
                        label13.Text = currentRoom.Category;
                        Player.IsActive = true;
                        turnLabel.Text = $"Your Turn";
                        turnLabel.ForeColor = Color.Green;
                    }
                    else
                    {
                        //MessageBox.Show($"Game Started Me {currentRoom.Owner} vs {Player.Name}\n in Room {currentRoom.RoomId} with category {currentRoom.Category}");
                        lobbyPanel.Hide();
                        gamePanel.Show();
                        label10.Text = currentRoom.Owner;
                        label11.Text = currentRoom.Guest;
                        label13.Text = currentRoom.Category;
                        Player.IsActive = false;
                        turnLabel.Text = $"{currentRoom.Owner}'s Turn";
                        turnLabel.ForeColor = Color.Red;
                    }

                    label16.Text = currentRoom.RoomId;
                    label13.Text = currentRoom.Category;
                    break;

                case CommandTypes.Play:
                    secretWord = currentRoom.secretWord;
                    JsonElement jsonPayload = (JsonElement)command.Payload;
                    PlayCommandPayLoad playCommand = jsonPayload.Deserialize<PlayCommandPayLoad>();
                    //PlayCommandPayLoad playCommand = JsonSerializer.Deserialize<PlayCommandPayLoad>(command.Payload.ToString());
                    currentRoom = playCommand.room;
                    //MessageBox.Show(command.Payload.ToString());
                    //MessageBox.Show(playCommand.room.Category);
                    //MessageBox.Show($"{playCommand.UserName} played {playCommand.Symbol} in room {playCommand.RoomId}");
                    Player.IsActive = true;

                    string controlName = playCommand.Symbol.ToString().ToLower() + "Btn";
                    Control pressedControl = gamePanel.Controls[controlName];
                    pressedControl.Enabled = false;


                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (secretWord[i].ToString() == playCommand.Symbol.ToString().ToLower())
                        {
                            Control textBox = gamePanel.Controls[$"txtBox{i + 1}"];
                            textBox.Text = playCommand.Symbol.ToString().ToLower();
                        }
                    }
                    //if (secretWord.Contains(playCommand.Symbol.ToString().ToLower()))
                    //{
                    //    Control textBox = gamePanel.Controls[$"txtBox{secretWord.IndexOf(playCommand.Symbol.ToString().ToLower()) + 1}"];
                    //    textBox.Text = playCommand.Symbol.ToString().ToLower();
                    //}
                    bool winFlag = true;
                    for (int i = 1; i <= secretWord.Length; i++)
                    {
                        Control textBox = gamePanel.Controls[$"txtBox{i}"];
                        if (textBox.Text == "")
                        {
                            winFlag = false;
                            break;
                        }
                    }
                    if (winFlag)
                    {
                        gamePanel.Hide();
                        conrgatOrSorryLabel.Text = $"Sorry {Player.Name}!";
                        winOrLoseLabel.Text = "You Lost!";
                        winOrLoseLabel.ForeColor = Color.Red;
                        winOrLosePanel.Show();
                        //MessageBox.Show($"{playCommand.UserName} Won, Sorry!");
                    }





                    // see if the current player is a spectator or not
                    if (!(Player.Name == currentRoom.Owner || Player.Name == currentRoom.Guest))
                    {
                        if (turnLabel.Text == $"{currentRoom.Owner}'s Turn")
                        {
                            turnLabel.Text = $"{currentRoom.Guest}'s Turn";
                        }
                        else if (turnLabel.Text == $"{currentRoom.Guest}'s Turn")
                        {
                            turnLabel.Text = $"{currentRoom.Owner}'s Turn";
                        }
                    }
                    else
                    {
                        turnLabel.Text = $"Your Turn";
                        turnLabel.ForeColor = Color.Green;
                    }

                    break;

                case CommandTypes.SpectateRoom:
                    GameRoom spectatedRoom = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                    currentRoom = spectatedRoom;
                    secretWord = currentRoom.secretWord;

                    for (int i = 1; i <= secretWord.Length; i++)
                    {
                        TextBox textBox = new TextBox
                        {
                            Name = $"txtBox{i}",   // Unique name
                            Width = 50,            // Set width
                            Height = 100,
                            BackColor = Color.Black,
                            ForeColor = Color.White,
                            Font = new Font("Arial", 15),
                            Location = new Point(i * 110, 200) // Positioning horizontally
                        };

                        gamePanel.Controls.Add(textBox); // Add to the panel
                        //textBox.Enabled = false;
                    }

                    string message = String.Join(", ", currentRoom.revelaedLetter.Select(b => b ? "1" : "0"));

                    //MessageBox.Show(message);
                    bool[] secretWordRevealed = new bool[secretWord.Length];
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        secretWordRevealed[i] = currentRoom.revelaedLetter[secretWord[i] - 'a'];
                    }

                    for (int i = 1; i <= secretWord.Length; i++)
                    {
                        if (secretWordRevealed[i - 1])
                        {
                            gamePanel.Controls[$"txtBox{i}"].Text = secretWord[i - 1].ToString();
                        }
                    }
                    // Hide other panels and show the spectating view
                    roomsListPanel.Hide();
                    lobbyPanel.Hide();
                    gamePanel.Show();

                    label10.Text = spectatedRoom.Owner; // Owner
                    label11.Text = spectatedRoom.Guest; // Guest
                    label13.Text = spectatedRoom.Category; // Category
                    label16.Text = spectatedRoom.RoomId; // Room ID

                    Player.IsActive = false; // Spectator should not be active
                    if (turnLabel.Text == "Your Turn")
                    {
                        turnLabel.Text = $"{currentRoom.Owner}'s Turn";
                    }
                    else if (turnLabel.Text == $"{currentRoom.Owner}'s Turn")
                    {
                        turnLabel.Text = $"{currentRoom.Guest}'s Turn";
                    }
                    else if (turnLabel.Text == $"{currentRoom.Guest}'s Turn")
                    {
                        turnLabel.Text = $"{currentRoom.Owner}'s Turn";
                    }
                    //MessageBox.Show("You are now spectating this game.");

                    label7.Hide();
                    label9.Hide();
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
            tryCategoriesComboBox.SelectedIndex = 0;
            roomCreationPanel.Show();
        }

        private void confirmCreationButton_Click(object sender, EventArgs e)
        {
            string takenRoomName = tryRoomNameTextBox.Text;
            string takenRoomCat = tryCategoriesComboBox.Text;
            GameRoom gameRoom = new GameRoom { RoomId = takenRoomName, Owner = Player.Name, Guest = "", IsOwnerReady = false, IsGuestReady = false, Category = takenRoomCat, State = GameState.Waiting, secretWord = getSecretWord(takenRoomCat) };
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

        private void readyButton_Click(string roomName)
        {

        }

        private void AddRoomPanel(string roomName, string creator, string otherPlayer, string status)
        {
            // Create the panel
            Panel roomPanel = new Panel
            {
                Size = new Size(250, 150),
                BackColor = Color.DarkGray,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Room Name Label (Larger and Bold)
            Label nameLabel = new Label
            {
                Text = $"Room: {roomName}",
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White
            };
            roomPanel.Controls.Add(nameLabel);

            // Room Creator Label
            Label creatorLabel = new Label
            {
                Text = $"Creator: {creator}",
                Location = new Point(10, 40),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Regular),
                ForeColor = Color.White
            };
            roomPanel.Controls.Add(creatorLabel);

            // Other Player Label
            Label playerLabel = new Label
            {
                Text = $"Other Player: {otherPlayer}",
                Location = new Point(10, 60),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Regular),
                ForeColor = Color.White
            };
            roomPanel.Controls.Add(playerLabel);

            // Room Status Label
            Label statusLabel = new Label
            {
                Text = $"Status: {status}",
                Location = new Point(10, 80),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Regular),
                ForeColor = Color.White
            };
            roomPanel.Controls.Add(statusLabel);

            // Join Button
            Button joinButton = new Button
            {
                Text = "Join",
                Size = new Size(100, 30),
                Location = new Point(10, 110),
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            joinButton.Click += (s, e) => { joinRoomButton_Click(roomName); };
            roomPanel.Controls.Add(joinButton);

            // Spectate Button
            Button spectateButton = new Button
            {
                Text = "Spectate",
                Size = new Size(100, 30),
                Location = new Point(130, 110),
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            spectateButton.Click += (s, e) => { spectateRoomButton_Click(roomName); };
            roomPanel.Controls.Add(spectateButton);

            // Add the panel to FlowLayoutPanel
            roomsListFlowLayout.Controls.Add(roomPanel);

            otherPlayer = otherPlayer ?? "";
            if (creator.Length > 0 && otherPlayer.Length > 0)
            {
                joinButton.Enabled = false;
            }
        }

        private void spectateRoomButton_Click(string roomName)
        {
            GameRoom gameRoom = new GameRoom { RoomId = roomName };
            Command spectateRequest = new Command(CommandTypes.SpectateRoom, gameRoom);
            sendCommand(spectateRequest);
        }

        private void ReadyButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"{roomName}");
            Command readyRequest = new Command(CommandTypes.RequestReady, currentRoom);
            sendCommand(readyRequest);
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            Command command = new Command(CommandTypes.StartGame, currentRoom);
            sendCommand(command);
        }

        private void keyClicked(object sender, EventArgs e)
        {
            if (Player.IsActive)
            {
                Button pushedButton = sender as Button;
                string controlName = pushedButton.Text.ToLower() + "Btn";
                Control pressedControl = gamePanel.Controls[controlName];

                currentRoom.revelaedLetter[pushedButton.Text[0].ToString().ToLower()[0] - 'a'] = true;
                pressedControl.Enabled = false;
                string pushedKey = pushedButton.Text;

                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i].ToString() == pushedKey.ToLower())
                    {
                        Control textBox = gamePanel.Controls[$"txtBox{i + 1}"];
                        textBox.Text = pushedKey.ToLower();
                    }
                }
                //if (secretWord.Contains(pushedKey.ToLower()))
                //{
                //    //MessageBox.Show("Hello");
                //    Control textBox = gamePanel.Controls[$"txtBox{secretWord.IndexOf(pushedKey.ToLower()) + 1}"];
                //    textBox.Text = pushedKey.ToLower();
                //}

                turnLabel.Text = $"{currentRoom.Guest}'s Turn";
                turnLabel.ForeColor = Color.Red;

                Command command = new Command(CommandTypes.Play, new PlayCommandPayLoad(Player.Name, pushedKey[0], currentRoom));
                sendCommand(command);
                Player.IsActive = false;
                bool winFlag = true;
                for (int i = 1; i <= secretWord.Length; i++)
                {
                    Control textBox = gamePanel.Controls[$"txtBox{i}"];
                    if (textBox.Text == "")
                    {
                        winFlag = false;
                        break;
                    }
                }
                if (winFlag)
                {
                    //MessageBox.Show($"You Won, Congatulations!");
                    gamePanel.Hide();
                    conrgatOrSorryLabel.Text = $"Congratulations! {Player.Name}";
                    winOrLosePanel.Show();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
