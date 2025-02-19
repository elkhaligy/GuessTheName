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
        //private Client client = new Client();
        public ClientForm()
        {
            InitializeComponent();
            //client.OnMessageReceived += Log;
            //client.onDisconnect += HandleDisconnect;

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
            //testRoom.Owner = "Shehab";
            //testRoom.Category = "Animal";
            //roomsForm.Rooms.Add(testRoom);
            //roomsForm.UpdateRoomsOnUI();
            this.Hide();
            //try
            //{
            //    if (String.IsNullOrWhiteSpace(userNameTextBox.Text))
            //    {
            //        MessageBox.Show("Please enter a username");
            //        return;
            //    }
            //    if (client.isConnected)
            //    {
            //        MessageBox.Show("Already connected");
            //        return;
            //    }
            //    client.Connect("127.0.0.1", 50000);
            //    connectButton.Enabled = false;
            //    connectedCheckBox.Checked = true;
            //    userNameTextBox.Enabled = false;

            //    // Construct the command that will be sent to the server as a json
            //    var loginCommand = new Command(CommandTypes.Login, new LoginCommandPayLoad(userNameTextBox.Text));
            //    client.SendCommand(loginCommand);

            //    Form roomForm = new RoomsForm(client);
            //    roomForm.Show();
            //    this.Hide();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error: {ex.Message} {ex}");

            //}
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
        //private void UpdateUI()
        //{
        //    if (InvokeRequired) // Check if we are on the UI thread
        //    {
        //        Invoke(new Action(UpdateUI));
        //        return;
        //    }
        //    UpdateConnectedClientsList();
        //}
        //private void Log(string message)
        //{
        //    receivedDataTextBox.Text += message + "\r\n";
        //}
        //private void HandleDisconnect()
        //{
        //    connectButton.Enabled = true;
        //    userNameTextBox.Enabled = true;
        //    connectedCheckBox.Checked = false;
        //}
    }
}
