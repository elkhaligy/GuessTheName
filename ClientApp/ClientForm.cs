using Shared;
using System.Data;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ClientApp
{
    public partial class ClientForm : Form
    {
        private TcpClient testClient = new TcpClient();
        private Thread clientMessageListeningThread;
        private Player player = new Player();
        private List<GameRoom> roomsListFromServerToDisplay = new List<GameRoom>();
        public ClientForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void connectButtonClick(object sender, EventArgs e)
        {
            testClient.Connect("127.0.0.1", 50000);
            player.tcpClient = testClient;
            player.Name = userNameTextBox.Text;
            player.Score = 0;
            clientMessageListeningThread = new Thread(() => listenForMessages()) { IsBackground = true };
            clientMessageListeningThread.Start();
            Command loggingRequest = new Command(CommandTypes.Login, player);
            sendCommand(loggingRequest);
            loginPanel.Hide(); // Hide login panel after logging in


            // Request rooms from the server
            Command command = new Command(CommandTypes.GetRooms, new GetRoomCommandPayload());
            sendCommand(command);

            roomsListPanel.Show();
        }

        private void sendCommand(Command command)
        {
            var stream = player.tcpClient.GetStream();
            var streamWriter = new StreamWriter(stream) { AutoFlush = true };
            var json = JsonSerializer.Serialize(command);
            streamWriter.WriteLine(json);
        }

        private void listenForMessages()
        {
            var stream = player.tcpClient.GetStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);

            while (true)
            {
                string? message = streamReader.ReadLine();
                //receivedDataTextBox.Text += message + "\r\n";
                Command? command = JsonSerializer.Deserialize<Command>(message);

                switch (command.CommandType)
                {
                    case CommandTypes.RoomCreated:
                        GameRoom receivedRoom = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                        MessageBox.Show("Room Created Successfully!");
   
                        break;
                    case CommandTypes.RoomsList:
                        List<GameRoom> roomsListFromServerToDisplay = JsonSerializer.Deserialize<List<GameRoom>>(command.Payload.ToString());
                        updateRoomsListGUI(roomsListFromServerToDisplay);
                        break;
                    default:
                        break;

                }
            }
        }

        public void updateRoomsListGUI(List<GameRoom> receivedRoomList)
        {
            if(InvokeRequired)
            {
                Invoke(new Action<List<GameRoom>>(updateRoomsListGUI), receivedRoomList);
                return;
            }
            testFlowLayout.Controls.Clear();
            foreach (var receivedRoom in receivedRoomList)
            {
                RoomUserControl roomControl = new RoomUserControl(receivedRoom.Owner, receivedRoom.RoomId, receivedRoom.Category);
                testFlowLayout.Controls.Add(roomControl);
            }
        }

        private void testCreateRoomButton_Click(object sender, EventArgs e)
        {
            string roomName;
            string roomCategory;

            RoomCreationForm roomCreationForm = new RoomCreationForm();
            if (roomCreationForm.ShowDialog() == DialogResult.OK)
            {
                roomName = roomCreationForm.RoomName;
                roomCategory = roomCreationForm.RoomCategory;
                GameRoom gameRoom = new GameRoom { RoomId = roomName, Owner = player.Name, Category = roomCategory };
                Command command = new Command(CommandTypes.CreateRoom, gameRoom);
                sendCommand(command);
            }
        }
    }
}
