using Shared;
using System.Collections.Generic;
using System.Data;
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
                    GameRoom receivedRoom;
                    GameRoom currentRoom;
                    TcpClient roomOwnerTcp;
                    TcpClient roomGuestTcp;

                    StreamWriter roomOwnerWriter;
                    StreamWriter roomGuestWriter;
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
                            OnLog?.Invoke($"Created room: {receivedRoomFromJson.RoomId} with secret word: {receivedRoomFromJson.secretWord} with owner name {receivedRoomFromJson.Owner}  by {tcpClient.Client.RemoteEndPoint}");
                            break;

                        case CommandTypes.GetRooms:
                            Command getRooms = new Command(CommandTypes.RoomsList, roomsList);
                            jsonMessage = JsonSerializer.Serialize(getRooms);
                            writer?.WriteLine(jsonMessage);
                            break;

                        case CommandTypes.JoinRoom:
                            string receivedRoomName = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString()).RoomId;
                            GameRoom currentJoinedRoom = roomsList.Find(room => room.RoomId == receivedRoomName);
                            currentJoinedRoom.Guest = tcpPlayerMap[tcpClient].Name;

                            jsonMessage = JsonSerializer.Serialize(new Command(CommandTypes.JoinRoom, currentJoinedRoom));
                            writer?.WriteLine(jsonMessage);
                            // Send to the owner of the room an update with the guest name
                            Command roomUpdated = new Command(CommandTypes.RoomUpdated, currentJoinedRoom);
                            jsonMessage = JsonSerializer.Serialize(roomUpdated);
                            TcpClient ownerTcpClient = nameToClientMap[currentJoinedRoom.Owner];
                            StreamWriter ownerWriter = new StreamWriter(ownerTcpClient.GetStream()) { AutoFlush = true };
                            ownerWriter?.WriteLine(jsonMessage);
                            break;

                        case CommandTypes.RequestReady:
                            receivedRoom = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                            currentRoom = roomsList.Find(room => room.RoomId == receivedRoom.RoomId);
                            string currentPlayerName = tcpPlayerMap[tcpClient].Name;
                            if (currentPlayerName == currentRoom.Owner)
                            {
                                currentRoom.IsOwnerReady = true;
                            }
                            else
                            {
                                currentRoom.IsGuestReady = true;
                            }
                            Command roomUpdatedCommand = new Command(CommandTypes.RoomUpdated, currentRoom);
                            jsonMessage = JsonSerializer.Serialize(roomUpdatedCommand);

                            var roomOwnerTcpClient = nameToClientMap[currentRoom.Owner];
                             roomOwnerWriter = new StreamWriter(roomOwnerTcpClient.GetStream()) { AutoFlush = true };
                            roomOwnerWriter?.WriteLine(jsonMessage);

                            if (currentRoom.Guest.Length > 0)
                            {
                                var roomGuestTcpClient = nameToClientMap[currentRoom.Guest];
                                 roomGuestWriter = new StreamWriter(roomGuestTcpClient.GetStream()) { AutoFlush = true };
                                roomGuestWriter?.WriteLine(jsonMessage);
                            }
                             break;

                        case CommandTypes.StartGame:
                            receivedRoom = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                            OnLog?.Invoke($"Game started in room {receivedRoom.secretWord}");
                            if (receivedRoom.IsOwnerReady && receivedRoom.IsGuestReady)
                            {
                                currentRoom = roomsList.Find(room => room.RoomId == receivedRoom.RoomId);
                                currentRoom.State = GameState.InProgress;
                                Command startGameCommand = new Command(CommandTypes.StartGame, currentRoom);
                                jsonMessage = JsonSerializer.Serialize(startGameCommand);
                                roomOwnerTcpClient = nameToClientMap[receivedRoom.Owner];
                                roomOwnerWriter = new StreamWriter(roomOwnerTcpClient.GetStream()) { AutoFlush = true };
                                roomOwnerWriter?.WriteLine(jsonMessage);

                                roomGuestTcp = nameToClientMap[receivedRoom.Guest];
                                roomGuestWriter = new StreamWriter(roomGuestTcp.GetStream()) { AutoFlush = true };
                                roomGuestWriter?.WriteLine(jsonMessage);
                            }
                            break;

                        case CommandTypes.Play:
                            PlayCommandPayLoad playCommandPayLoad = JsonSerializer.Deserialize<PlayCommandPayLoad>(command.Payload.ToString());
                            string playerThatPlayed = playCommandPayLoad.UserName;
                            GameRoom playedRoom = playCommandPayLoad.room;
                            char keyPressed = playCommandPayLoad.Symbol;
                            currentRoom = roomsList.Find(room => room.RoomId == playCommandPayLoad.room.RoomId);
                            currentRoom.revelaedLetter = playedRoom.revelaedLetter;

                            if (playerThatPlayed == currentRoom.Owner)
                            {
                                roomGuestTcp = nameToClientMap[currentRoom.Guest];
                                roomGuestWriter = new StreamWriter(roomGuestTcp.GetStream()) { AutoFlush = true };
                                Command startGameCommand = new Command(CommandTypes.Play, new PlayCommandPayLoad (currentRoom.Owner,keyPressed, currentRoom));
                                jsonMessage = JsonSerializer.Serialize(startGameCommand);
                                roomGuestWriter?.WriteLine(jsonMessage);
                            }
                            else
                            {
                                roomOwnerTcpClient = nameToClientMap[currentRoom.Owner];
                                roomOwnerWriter = new StreamWriter(roomOwnerTcpClient.GetStream()) { AutoFlush = true };
                                Command startGameCommand = new Command(CommandTypes.Play, new PlayCommandPayLoad(currentRoom.Guest, keyPressed, currentRoom));
                                jsonMessage = JsonSerializer.Serialize(startGameCommand);
                                roomOwnerWriter?.WriteLine(jsonMessage);

                            }

                            foreach (var spectator in currentRoom.Spectators)
                            {
                                TcpClient spectatorTcp = nameToClientMap[spectator.Name];
                                StreamWriter spectatorWriter = new StreamWriter(spectatorTcp.GetStream()) { AutoFlush = true };
                                Command startGameCommand = new Command(CommandTypes.Play, new PlayCommandPayLoad(playerThatPlayed, keyPressed, currentRoom));
                                jsonMessage = JsonSerializer.Serialize(startGameCommand);
                                spectatorWriter?.WriteLine(jsonMessage);
                            }
                            break;
                        case CommandTypes.SpectateRoom:
                            GameRoom spectatedRoom = JsonSerializer.Deserialize<GameRoom>(command.Payload.ToString());
                            string spectatedRoomName = spectatedRoom.RoomId;
                            GameRoom spectatedRoomDetails = roomsList.Find(room => room.RoomId == spectatedRoomName);
                            spectatedRoomDetails.Spectators.Add(tcpPlayerMap[tcpClient]);
                            Command spectateRoomCommand = new Command(CommandTypes.SpectateRoom, spectatedRoomDetails);
                            jsonMessage = JsonSerializer.Serialize(spectateRoomCommand);
                            writer?.WriteLine(jsonMessage);
                            break;

                        case CommandTypes.UpdatePlayed:
                            PlayCommandPayLoad playCommandPayLoad2 = JsonSerializer.Deserialize<PlayCommandPayLoad>(command.Payload.ToString());
                            string playerThatPlayed2 = playCommandPayLoad2.UserName;
                            GameRoom playedRoom2 = playCommandPayLoad2.room;
                            char keyPressed2 = playCommandPayLoad2.Symbol;
                            currentRoom = roomsList.Find(room => room.RoomId == playCommandPayLoad2.room.RoomId);
                            currentRoom.revelaedLetter = playedRoom2.revelaedLetter;

                            if (playerThatPlayed2 == currentRoom.Owner)
                            {
                                roomGuestTcp = nameToClientMap[currentRoom.Guest];
                                roomGuestWriter = new StreamWriter(roomGuestTcp.GetStream()) { AutoFlush = true };
                                Command startGameCommand = new Command(CommandTypes.UpdatePlayed, new PlayCommandPayLoad(currentRoom.Owner, keyPressed2, currentRoom));
                                jsonMessage = JsonSerializer.Serialize(startGameCommand);
                                roomGuestWriter?.WriteLine(jsonMessage);
                            }
                            else
                            {
                                roomOwnerTcpClient = nameToClientMap[currentRoom.Owner];
                                roomOwnerWriter = new StreamWriter(roomOwnerTcpClient.GetStream()) { AutoFlush = true };
                                Command startGameCommand = new Command(CommandTypes.UpdatePlayed, new PlayCommandPayLoad(currentRoom.Guest, keyPressed2, currentRoom));
                                jsonMessage = JsonSerializer.Serialize(startGameCommand);
                                roomOwnerWriter?.WriteLine(jsonMessage);

                            }

                            foreach (var spectator in currentRoom.Spectators)
                            {
                                TcpClient spectatorTcp = nameToClientMap[spectator.Name];
                                StreamWriter spectatorWriter = new StreamWriter(spectatorTcp.GetStream()) { AutoFlush = true };
                                Command startGameCommand = new Command(CommandTypes.UpdatePlayed, new PlayCommandPayLoad(playerThatPlayed2, keyPressed2, currentRoom));
                                jsonMessage = JsonSerializer.Serialize(startGameCommand);
                                spectatorWriter?.WriteLine(jsonMessage);
                            }
                            break;
                        default:
                            break;
                            
                    }
                }
                catch (Exception) { break; }
            }

            lock (players)
            {

                // Remove the rooms created by the disconnected client
                // We have the tcp client and we have the player by that using the dictionary
                // room owner is the player name, so ez
                string leftPlayerName = tcpPlayerMap[tcpClient].Name;
                foreach (GameRoom room in roomsList)
                {
                    if (room.Owner == leftPlayerName)
                    {
                        roomsList.Remove(room);
                        break;
                    }
                }

                foreach (Player player in players)
                {
                    if (player.tcpClient == tcpClient)
                    {
                        players.Remove(player);
                        break;
                    }
                }
                players.Remove(tcpPlayerMap[tcpClient]);
                nameToClientMap.Remove(tcpPlayerMap[tcpClient].Name);
                tcpPlayerMap.Remove(tcpClient);
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
