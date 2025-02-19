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
        private RoomsForm roomsForm;

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

            // Send the server a request to login
            Command loggingRequest = new Command(CommandTypes.Login, player);
            sendCommand(loggingRequest);

            roomsForm = new RoomsForm(player);
            roomsForm.Show();
            GameRoom testRoom = new GameRoom();
            this.Hide();
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
                        updatetest(receivedRoom);
                        break;
                    case CommandTypes.RoomsList:
                        List<GameRoom> receivedRoomsList = JsonSerializer.Deserialize<List<GameRoom>>(command.Payload.ToString());
                        //roomsForm.Rooms = receivedRoomsList;
                        updateRoomsOnUIAfterLogin(receivedRoomsList);
                        //roomsForm.UpdateRoomsOnUI();

                        break;
                    default:
                        break;

                }
            }
        }

        public void updatetest(GameRoom gameRoom)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<GameRoom>(updatetest), gameRoom);
                return;
            }
            roomsForm.Rooms.Add(gameRoom);
            roomsForm.UpdateRoomsOnUI();
        }

        public void updateRoomsOnUIAfterLogin(List<GameRoom> gameRoomList)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<GameRoom>>(updateRoomsOnUIAfterLogin), gameRoomList);
                return;
            }
            roomsForm.Rooms = gameRoomList;
            roomsForm.UpdateRoomsOnUI();
        }
    }
}
