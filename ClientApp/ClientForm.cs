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
            clientMessageListeningThread = new Thread(() => listenForMessages(player)) { IsBackground = true };
            clientMessageListeningThread.Start();
            sendCommand(player, new Command(CommandTypes.Login, new LoginCommandPayLoad(player.Name)));
            roomsForm = new RoomsForm(player);
            roomsForm.Show();
            GameRoom testRoom = new GameRoom();
            this.Hide();
        }

        private void sendCommand(Player tcpClient, Command command)
        {
            var stream = player.tcpClient.GetStream();
            var streamWriter = new StreamWriter(stream) { AutoFlush = true };
            var json = JsonSerializer.Serialize(command);
            streamWriter.WriteLine(json);
        }

        private void listenForMessages(Player tcpClient)
        {
            var stream = player.tcpClient.GetStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);

            while (true)
            {
                string? message = streamReader.ReadLine();
                receivedDataTextBox.Text += message + "\r\n";
                Command? command = JsonSerializer.Deserialize<Command>(message);

                switch (command.CommandType)
                {
                    case CommandTypes.RoomCreated:
                        GameRoom receivedRoom = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                        updatetest(receivedRoom);
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

    }
}
