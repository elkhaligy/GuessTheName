using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class RoomCreationForm : Form
    {
        public string RoomCategory { get; set; }
        public string RoomName { get; set; }

        public RoomCreationForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            RoomCategory = comboBox.Text;
            RoomName = textBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
