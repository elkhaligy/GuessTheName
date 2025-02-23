using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class GameRoom
    {
        public string RoomId { get; set; }
        public string Owner { get; set; }
        public string Guest { get; set; }

        public bool IsOwnerReady { get; set; }

        public bool IsGuestReady { get; set; }
        public List<Player> Spectators { get; set; } = new List<Player>();

        public bool[] revelaedLetter { get; set; } = new bool[26];

        public string Category { get; set; }
        public string secretWord { get; set; }
        public GameState State { get; set; }

        public bool CanJoin() => Guest == null && State == GameState.Waiting;
        public bool CanSpectate() => State == GameState.InProgress;
    }
}
