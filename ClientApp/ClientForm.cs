using Shared;
using System.Data;
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
            roomsListPanel.Show();
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
                    MessageBox.Show("Room Created Successfully!");
                    break;
                case CommandTypes.RoomsList:
                    roomsListFromServerToDisplay = JsonSerializer.Deserialize<List<GameRoom>>(command.Payload.ToString());
                    updateRoomsListGUI();
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
                RoomUserControl roomControl = new RoomUserControl(receivedRoom.Owner, receivedRoom.RoomId, receivedRoom.Category);
                roomsListFlowLayout.Controls.Add(roomControl);
            }
        }

        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            string roomName;
            string roomCategory;

            RoomCreationForm roomCreationForm = new RoomCreationForm();
            if (roomCreationForm.ShowDialog() == DialogResult.OK)
            {
                roomName = roomCreationForm.RoomName;
                roomCategory = roomCreationForm.RoomCategory;
                GameRoom gameRoom = new GameRoom { RoomId = roomName, Owner = Player.Name, Category = roomCategory };
                Command command = new Command(CommandTypes.CreateRoom, gameRoom);
                sendCommand(command);
            }
        }

        private void refreshRoomsButton_Click(object sender, EventArgs e)
        {
            Command command = new Command(CommandTypes.GetRooms, new GetRoomCommandPayload());
            sendCommand(command);
        }
    }

}
