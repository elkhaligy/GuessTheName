using Shared;
using System.Net;
using System.Net.Sockets;

namespace ServerApp
{
    public partial class ServerForm : Form
    {
        private Server server = new Server(IPAddress.Any, 50000); // Create a new server
        public ServerForm()
        {
            InitializeComponent();
            server.OnLog += Log;            // Subscribe to the OnLog event
            server.OnUpdate += UpdateUI;    // Subscribe to the OnUpdate event
            DoubleBuffered = true;
        }
        private async void startServerButton_Click(object sender, EventArgs e)
        {
            startServerButton.Enabled = false;
            stopServerButton.Enabled = true;
            startServerButton.Text = "Running";
            TcpListener listener = new TcpListener(IPAddress.Any, 50000);
            listener.Start();
            Log("Server Started");
            while (true)
            {
                /*
                 * Run a background task
                 * Save the current execution point
                 * Free the main thread
                 * When the function is done, return to the saved execution point
                 * Logically, here the ui thread is free and when the task is done it returns control to the ui thread
                 * in the same place it was called from so the message loop is not disturbed
                 */
                TcpClient tcpClient = await listener.AcceptTcpClientAsync();

                /*
                 * Once you have a client connected
                 * Handle this client in a new background task
                 * But I do not want to wait for a result from this task
                 * So I will not await this task
                 * Instead I will just let it run in the background and the main thread can continue back the while loop
                 */
                _ = HandleClientAsync(tcpClient);
            }
            //server.StartServer();



        }

        async Task HandleClientAsync(TcpClient tcpClient)
        {
            using(tcpClient)
            using(NetworkStream stream = tcpClient.GetStream())
            using(StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
            {
                Log("Client connected");
                while(tcpClient.Connected)
                {
                    string jsonRequest = await reader.ReadLineAsync();
                    if (jsonRequest == null) { break; }
                    Log($"Request received from the client: {jsonRequest}");
                    // Handle the request
                    string jsonResponse = "{\"status\" : \"ok\"}";
                    await writer.WriteLineAsync(jsonResponse);
                    Log($"Response send to the client: {jsonResponse}");
                    //MessageBox.Show("Hello");
                }
            }
        }
        private void Log(string message) // Subscriber method to Server class OnLog event
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Log), message);
                return;
            }
            clientMessagesTextBox.AppendText(message + "\r\n");
        }

        private void UpdateUI()
        {
            if (InvokeRequired) // Check if we are on the UI thread
            {
                Invoke(new Action(UpdateUI));
                return;
            }
            UpdateConnectedClientsList();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            //server.BroadcastMessage("Hello");
        }


        private void UpdateConnectedClientsList()
        {
            connectedClientsListBox.Clear();
            foreach (Player player in  server.Players)
            {
                connectedClientsListBox.Text += player.Name + "\r\n";
            }
        }

        private void stopServerButton_Click(object sender, EventArgs e)
        {
            server.StopServer();
            stopServerButton.Enabled = false;
            startServerButton.Enabled = true;
            startServerButton.Text = "Start";
        }
    }
}
