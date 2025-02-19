using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class GameRoom
    {
        List<Player> players = new List<Player>();

        public string RoomId { get; set; }
        public string Owner { get; set; }
        public string Guest { get; set; }

        public List<Player> Spectators { get; set; }

        public string Category { get; set; }

        public GameState State { get; set; }

        public bool CanJoin() => Guest == null && State == GameState.Waiting;
        public bool CanSpectate() => State == GameState.InProgress;
    }
}
