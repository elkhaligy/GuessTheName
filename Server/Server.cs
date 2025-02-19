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
        public List<GameRoom> roomsList = new List<GameRoom>();
        public List<Player> Players { get { return players; } }

        public Dictionary<TcpClient, Player> tcpPlayerMap = new Dictionary<TcpClient, Player>();
        public Dictionary<string, TcpClient> nameToClientMap = new Dictionary<string, TcpClient>();


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

        private void HandleClient(TcpClient tcpClient)
        {
            OnLog?.Invoke($"Client connected: {tcpClient.Client.RemoteEndPoint}");
            NetworkStream stream = tcpClient.GetStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };


            while (isRunning && tcpClient.Connected)
            {
                try
                {
                    string? message = reader.ReadLine();
                    string jsonMessage;
                    if (message == null) break;
                    OnLog?.Invoke($"Received: {message} from {tcpClient.Client.RemoteEndPoint}");
                    Command? command = JsonSerializer.Deserialize<Command>(message);

                    switch (command.CommandType)
                    {
                        case CommandTypes.Login:
                            Player receivedPlayerFromJson = JsonSerializer.Deserialize<Player>(command.Payload.ToString());
                            receivedPlayerFromJson.tcpClient = tcpClient;
                            players.Add(receivedPlayerFromJson);
                            tcpPlayerMap.Add(tcpClient, receivedPlayerFromJson);
                            nameToClientMap.Add(receivedPlayerFromJson.Name, tcpClient);
                            OnUpdate?.Invoke();
                            break;

                        case CommandTypes.CreateRoom:
                            CreateRoomCommandPayload createRoomPayload = JsonSerializer.Deserialize<CreateRoomCommandPayload>(command.Payload.ToString());
                            GameRoom receivedRoomFromJson = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                            roomsList.Add(receivedRoomFromJson);
                            // Send the created room
                            Command roomCreated = new Command(CommandTypes.RoomCreated, receivedRoomFromJson);
                            jsonMessage = JsonSerializer.Serialize(roomCreated);
                            writer?.WriteLine(jsonMessage);
                            OnLog?.Invoke($"Created room: {receivedRoomFromJson.RoomId} with owner name {receivedRoomFromJson.Owner}  by {tcpClient.Client.RemoteEndPoint}");
                            break;

                        case CommandTypes.GetRooms:
                            Command getRooms = new Command(CommandTypes.RoomsList, roomsList);
                            jsonMessage = JsonSerializer.Serialize(getRooms);
                            writer?.WriteLine(jsonMessage);
                            break;

                        case CommandTypes.JoinRoom:
                            // To join a room a player need to send the room name he wants  ONLY
                            // You will use the room name to search for the required room in the list of rooms
                            // When the required room is picked add the name of the player to the guest field
                            // Now obtain the tcp client of the player that sent the request and prepare a message for him
                            // In this message send him the room he joined with SuccessfulJoin command
                            // The client then should act on this by creating a lobby
                            // The client has the full details it needs, like who is the owner of the room and the room details
                            //string receivedRoomName = "dummy";
                            //GameRoom neededRoom;
                            //foreach (GameRoom room in roomsList)
                            //{
                            //    if (room.RoomId == receivedRoomName) 
                            //    {
                            //        neededRoom = room;
                            //        break;
                            //    }
                            //}
                            //neededRoom.Guest = tcpPlayerMap[tcpClient].Name;

                            // After you handled this you need to notify both the owner and the guest

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
                    if (player.tcpClient == tcpClient)
                    {
                        players.Remove(player);
                        break;
                    }
                }
                OnLog?.Invoke($"Client disconnected: {tcpClient.Client.RemoteEndPoint}");
                OnUpdate?.Invoke(); // Notify the subscribers
            }
            tcpClient.Close();
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
