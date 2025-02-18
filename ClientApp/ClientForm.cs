using ClientApp.Views;
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
            //Application.Exit();
            try
            {
                connectButton.Invoke(() =>
                {
                    MessageBox.Show("You're Disconnected. Try to reconnect again");
                    connectButton.Enabled = true;
                    userNameTextBox.Enabled = true;
                    connectedCheckBox.Checked = false;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm frm = new GameForm();
            frm.Show();
            frm.Focus();
            frm.FormClosed += (s, args) => this.Close();

        }
    }
}
