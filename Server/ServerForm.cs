using System.Net;

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
        }
        private void startServerButton_Click(object sender, EventArgs e)
        {
            server.StartServer();
            startServerButton.Enabled = false;
            stopServerButton.Enabled = true;
            startServerButton.Text = "Running";
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
            server.BroadcastMessage("Hello");
        }


        private void UpdateConnectedClientsList()
        {
            connectedClientsListBox.Clear();
            foreach (String player in server.Players.Values)
            {
                connectedClientsListBox.Text += player + "\r\n";
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
