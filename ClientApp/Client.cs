using Shared;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ClientApp
{
    public class Client
    {
        private TcpClient? tcpClient;
        private StreamReader? streamReader;
        private StreamWriter? streamWriter;
        private Thread? listeningThread;
        private bool isRunning = false;
        public string UserName { get; set; } = "";
        public bool isConnected => tcpClient != null && tcpClient.Connected;

        public event Action<string>? OnMessageReceived;     // Event that can be subscribed to
        public event Action? onDisconnect;                  // Event that can be subscribed to

        public void Connect(string ip, int port)
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ip, port);
                var stream = tcpClient.GetStream();
                streamReader = new StreamReader(stream, Encoding.UTF8);
                streamWriter = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
                isRunning = true;
                listeningThread = new Thread(ListenForMessages) { IsBackground = true };
                listeningThread.Start();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message} {ex}");
            }

        }

        public void ListenForMessages()
        {
            try
            {
                while (isRunning && isConnected)
                {
                    string? message = streamReader.ReadLine();
                    if (message == null) break; // Connection is closed

                    // Handling received messages logic ####
                    //Command? command = JsonSerializer.Deserialize<Command>(message);
                    //switch (command.CommandType)
                    //{
                    //    //case
                    //    //    break;
                    //    //default:
                    //    //    break;
                    //}
                    OnMessageReceived.Invoke(message);
                }
            }
            catch (Exception ex)
            {
                Disconnect();
                //throw new Exception($"Error: {ex.Message} {ex}");
            }

        }
        public void SendCommand(Command command)
        {
            try
            {
                string jsonMessage = JsonSerializer.Serialize(command);
                streamWriter?.WriteLine(jsonMessage);
            }
            catch (Exception e)
            {
                throw new Exception($"Error: {e.Message} {e}");
            }
        }
        public void Disconnect() // This happens incase the server went down
        {
            isRunning = false;
            tcpClient?.Close();
            streamReader?.Close();
            streamWriter?.Close();
            onDisconnect?.Invoke();
            listeningThread.Join();
            listeningThread = null;
            onDisconnect?.Invoke(); // Notify the subscribers
        }
    }

}
