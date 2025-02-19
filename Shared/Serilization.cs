using System.Net.Sockets;
using System.Text.Json.Serialization;

namespace Shared
{
    public enum CommandTypes
    {
        Login,      // Client sends this command to the server to login
        Play,       // Client sends this command to the server to notify it of a play
        GetRooms,   // Client sends this command to the server to get the list of rooms
        RoomsList,  // Server sends this command to the client to send the list of rooms
        CreateRoom, // Client sends this command to the server to create a room
        JoinRoom,   // Client sends this command to the server to join a room
        RoomCreated,
        StartGame,
        RoomUpdated,
        Quit
    }
    public class Command
    {
        public CommandTypes CommandType { get; set; }
        public object Payload { get; set; }

        public Command(CommandTypes commandType, object payload)
        {
            CommandType = commandType;
            Payload = payload;
        }

    }
    public class Payload
    {
        public string UserName { get; set; }
        public char? Symbol { get; set; }

        public Payload(string UserName)
        {
            this.UserName = UserName;
        }

        public Payload(char Symbol)
        {
            this.Symbol = Symbol;
        }
    }
    public class LoginCommandPayLoad
    {
        public string UserName { get; set; }

        public LoginCommandPayLoad(string userName)
        {
            UserName = userName;
        }
    }

    public class PlayCommandPayLoad
    {
        public string UserName { get; set; }
        public char Symbol { get; set; }

        public PlayCommandPayLoad(string username, char symbol)
        {
            UserName = username;
            Symbol = symbol;
        }
    }

    public class DisconnectCommandPayLoad
    {
        public string UserName { get; set; }
        public DisconnectCommandPayLoad(string userName)
        {
            UserName = userName;
        }
    }

    public class GetRoomCommandPayload
    {

    }

    public class CreateRoomCommandPayload
    {
        public string RoomOwner { get; set; }

        public string RoomName { get; set; }

        public string RoomCategory { get; set; }

        public CreateRoomCommandPayload(string roomOwner, string roomName, string roomCategory)
        {
            RoomOwner = roomOwner;
            RoomName = roomName;
            RoomCategory = roomCategory;
        }
    }

 
}
