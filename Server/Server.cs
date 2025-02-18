using Shared;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ServerApp
{
    public class Server
    {
        private TcpListener? server;
        private Dictionary<TcpClient, string> players = new Dictionary<TcpClient, string>();
        private Thread? serverThread;
        private bool isRunning = false;
        public event Action<string>? OnLog; // Event that can be subscribed to
        public event Action? OnUpdate;      // Event that can be subscribed to

        public Dictionary<TcpClient, string> Players { get { return players; } }
        private int Port { get; set; }
        private IPAddress IpAddress { get; set; }

        public Server(IPAddress ip, int port)
        {
            IpAddress = ip;
            Port = port;
        }
        public void StartServer()
        {
            if (isRunning) return;
            isRunning = true;
            StartListening();
            serverThread = new Thread(() => StartAcceptingClients()) { IsBackground = true };
            serverThread.Start();
            OnLog?.Invoke($"Server started on port {Port}...");
        }
        private void StartListening()
        {
            server = new TcpListener(IpAddress, Port);
            server.Start();
        }
        private void StartAcceptingClients()
        {
            while (isRunning)
            {
                try
                {
                    if (server == null) throw new InvalidOperationException("Server is not initialized.");
                    TcpClient client = server.AcceptTcpClient();
                    Thread clientThread = new Thread(() => HandleClient(client)) { IsBackground = true };
                    clientThread.Start();
                }
                catch (SocketException) { break; }
            }
        }

        private void HandleClient(TcpClient client)
        {
            OnLog?.Invoke($"Client connected: {client.Client.RemoteEndPoint}");
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };


            while (isRunning && client.Connected)
            {
                try
                {
                    string? message = reader.ReadLine();
                    if (message == null) break;
                    OnLog?.Invoke($"Received: {message} from {client.Client.RemoteEndPoint}");

                    Command? command = JsonSerializer.Deserialize<Command>(message);
                    switch(command.CommandType)
                    {
                        case CommandTypes.Login:
                            LoginCommandPayLoad? loginPayload = JsonSerializer.Deserialize<LoginCommandPayLoad>(command.Payload.ToString());
                            players[client] = loginPayload.UserName;
                            OnUpdate?.Invoke();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception) { break; }
            }

            lock (players)
            {
                players.Remove(client);
                OnLog?.Invoke($"Client disconnected: {client.Client.RemoteEndPoint}");
                OnUpdate?.Invoke(); // Notify the subscribers
            }
            client.Close();
        }

        public void BroadcastMessage(string message)
        {
            lock (players)
            {
                foreach (var player in players.Keys)
                {
                    try 
                    {
                        var stream = player.GetStream();
                        var streamWriter = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
                        streamWriter.WriteLine(message);
                    }
                    catch (Exception) 
                    {
                        MessageBox.Show("Error sending message to client");
                        player.Close(); 
                    }
                }
            }
        }

        public void StopServer()
        {
            isRunning = false;
            server?.Stop();
            lock (players)
            {
                foreach (var player in players.Keys)
                {
                    player.Close();
                }
                players.Clear();
            }
            OnLog?.Invoke("Server stopped.");
        }
    }
}
