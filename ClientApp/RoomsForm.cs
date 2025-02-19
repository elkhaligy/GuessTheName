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
        public List<GameRoom> Rooms { get { return rooms; } set { rooms = value; } }

        public RoomsForm(Player player)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.player = player;

            // Request rooms from the server
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
                GameRoom gameRoom = new GameRoom { RoomId = roomName, Owner = player.Name, Category = roomCategory};
                //Command command = new Command(CommandTypes.CreateRoom, new CreateRoomCommandPayload(player.Name, roomName, roomCategory));
                Command command = new Command(CommandTypes.CreateRoom, gameRoom);
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
