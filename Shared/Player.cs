using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared
{
    public class Player
    {
        [JsonIgnore]
        public TcpClient tcpClient { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsRoomOwner { get; set; }
        public String CurrentRoom { get; set; }
        public int Score { get; set; }
    }
}
