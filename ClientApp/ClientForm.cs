using Shared;
using System.Data;
using System.Net.Sockets;
using System.Text.Json;

namespace ClientApp
{
    public partial class ClientForm : Form
    {
        //private TcpClient tcpClient;
        //private StreamReader streamReader;
        //private StreamWriter streamWriter;

        private Client client = new Client();
        public ClientForm()
        {
            InitializeComponent();
            client.OnMessageReceived += Log;
            client.onDisconnect += HandleDisconnect;
        }


        private void connectButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(userNameTextBox.Text))
                {
                    MessageBox.Show("Please enter a username");
                    return;
                }
                if (client.isConnected)
                {
                    MessageBox.Show("Already connected");
                    return;
                }
                client.Connect("127.0.0.1", 50000);
                connectButton.Enabled = false;
                connectedCheckBox.Checked = true;
                userNameTextBox.Enabled = false;

                // Construct the command that will be sent to the server as a json
                var loginCommand = new Command(CommandTypes.Login, new LoginCommandPayLoad(userNameTextBox.Text));
                client.SendCommand(loginCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message} {ex}");

            }

        }

        private void Log(string message)
        {
            receivedDataTextBox.Text += message + "\r\n";
        }
        private void HandleDisconnect()
        {
            connectButton.Enabled = true;
            userNameTextBox.Enabled = true;
            connectedCheckBox.Checked = false;
        }
    }
}
