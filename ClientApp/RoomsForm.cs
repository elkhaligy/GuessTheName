using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;

namespace ClientApp
{
    public partial class RoomsForm : Form
    {
        private Player player;
        private List<GameRoom> rooms = new List<GameRoom>();
        private Dictionary<GameRoom, Room> roomMap = new Dictionary<GameRoom, Room>();
        
        // Create getters and setters for rooms
        public List<GameRoom> Rooms { get { return rooms; } }


        public RoomsForm(Player player)
        {
            InitializeComponent();
            //Room room1 = new Room();
            //Room room2 = new Room();
            //Room room3 = new Room();
            //Room room4 = new Room();

            //roomsContainer.Controls.Add(room1);
            //roomsContainer.Controls.Add(room2);
            //roomsContainer.Controls.Add(room3);
            //roomsContainer.Controls.Add(room4);

            this.player = player;
            Command command = new Command(CommandTypes.GetRooms, new GetRoomCommandPayload());
            sendCommand(player, command);

        }
        private void sendCommand(Player player, Command command)
        {
            var stream = player.tcpClient.GetStream();
            var streamWriter = new StreamWriter(stream) { AutoFlush = true };
            var json = JsonSerializer.Serialize(command);
            streamWriter.WriteLine(json);
        }
        private void RoomsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void createRoomButton_Click(object sender, EventArgs e)
        {
            string roomName;
            string roomCategory;

            RoomCreationForm roomCreationForm = new RoomCreationForm();
            if (roomCreationForm.ShowDialog() == DialogResult.OK)
            {
                roomName = roomCreationForm.RoomName;
                roomCategory = roomCreationForm.RoomCategory;
                Command command = new Command(CommandTypes.CreateRoom, new CreateRoomCommandPayload(player.Name, roomName, roomCategory));
                sendCommand(player, command);
            }

        }

        public void UpdateRoomsOnUI()
        {
            roomsContainer.Controls.Clear();
            foreach (GameRoom room in rooms)
            {
                Room roomControl = new Room(room.Owner, room.RoomId, room.Category);
                roomsContainer.Controls.Add(roomControl); 
            }
        }
    }
}
