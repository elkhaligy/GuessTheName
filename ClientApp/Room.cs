﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Room : UserControl
    {

        public Room(string roomOwner, string roomName, string roomCategory)
        {
            InitializeComponent();
            roomNameLabel.Text = roomName;
            roomCategoryLabel.Text = roomCategory;
            roomOwnerLabel.Text = roomOwner;
        }

        private void joinRoomButton_Click(object sender, EventArgs e)
        {

        }
    }
}
