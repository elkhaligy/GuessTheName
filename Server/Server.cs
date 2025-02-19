using Shared;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace ServerApp
{
    public class Server
    {
        private TcpListener? tcpListener;
        private int Port { get; set; }
        private IPAddress IpAddress { get; set; }
        private Thread? serverThread;
        public event Action<string>? OnLog; // Event that can be subscribed to
        public event Action? OnUpdate;      // Event that can be subscribed to
        private bool isRunning = false;
        private List<Player> players = new List<Player>();
        public List<GameRoom> rooms = new List<GameRoom>();

        public List<Player> Players { get { return players; } }

        public Server(IPAddress ip, int port)
        {
            IpAddress = ip;
            Port = port;
        }


        //private Dictionary<TcpClient, string> players = new Dictionary<TcpClient, string>();
        //public Dictionary<TcpClient, string> Players { get { return players; } }


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
            tcpListener = new TcpListener(IpAddress, Port);
            tcpListener.Start();
        }
        private void StartAcceptingClients()
        {
            while (isRunning)
            {
                try
                {
                    if (tcpListener == null) throw new InvalidOperationException("Server is not initialized.");
                    TcpClient client = tcpListener.AcceptTcpClient();
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
                    switch (command.CommandType)
                    {
                        case CommandTypes.Login:
                            LoginCommandPayLoad? loginPayload = JsonSerializer.Deserialize<LoginCommandPayLoad>(command.Payload.ToString());
                            Player player = new Player();
                            player.tcpClient = client;
                            player.Name = loginPayload.UserName;
                            player.Score = 0;
                            players.Add(player);
                            OnUpdate?.Invoke();
                            //players[client] = loginPayload.UserName;
                            break;
                        case CommandTypes.CreateRoom:
                            CreateRoomCommandPayload createRoomPayload = JsonSerializer.Deserialize<CreateRoomCommandPayload>(command.Payload.ToString());
                            GameRoom room = new GameRoom();
                            room.Owner = createRoomPayload.RoomOwner;
                            room.RoomId = createRoomPayload.RoomName;
                            room.Category = createRoomPayload.RoomCategory;
                            
                            Command roomCreated = new Command(CommandTypes.RoomCreated, room);
                            string jsonMessage = JsonSerializer.Serialize(roomCreated);
                            writer?.WriteLine(jsonMessage);


                            OnLog?.Invoke($"Created room: {room.RoomId} with owner name {room.Owner}  by {client.Client.RemoteEndPoint}");
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception) { break; }
            }

            lock (players)
            {
                foreach (Player player in players)
                {
                    if (player.tcpClient == client)
                    {
                        players.Remove(player);
                        break;
                    }
                }
                OnLog?.Invoke($"Client disconnected: {client.Client.RemoteEndPoint}");
                OnUpdate?.Invoke(); // Notify the subscribers
            }
            client.Close();
        }


        public void StopServer()
        {
            isRunning = false;
            tcpListener?.Stop();
            lock (players)
            {
                foreach (var player in players)
                {
                    player.tcpClient.Close();
                }
                players.Clear();
            }
            OnLog?.Invoke("Server stopped.");
        }

        //    public void BroadcastMessage(string message)
        //    {
        //        lock (players)
        //        {
        //            foreach (var player in players)
        //            {
        //                try
        //                {
        //                    var stream = player.tcpClient.GetStream();
        //                    var streamWriter = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

        //                    streamWriter.WriteLine(message);
        //                }
        //                catch (Exception)
        //                {
        //                    MessageBox.Show("Error sending message to client");
        //                    player.tcpClient.Close();
        //                }
        //            }
        //        }
        //    }

        //}



    }
}
