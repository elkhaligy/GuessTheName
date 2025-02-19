using ClientApp.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp.Views
{
    public partial class GameForm : Form
    {
        private GamePresenter presenter;
      
        public GameForm()
        {
            InitializeComponent();
            this.KeyPress += keyPressed;
        }

        private void keyPressed(object? sender, KeyPressEventArgs e)
        {
            char pressedLetter = e.KeyChar;
        }

       

        private void letterClicked(object sender, EventArgs e)
        {
            if (sender is Button b)
            {

                char guessedLetter = b.Text[0]; 
                bool correct = presenter.CHECK(guessedLetter);
                if (correct)
                {
                    lblSecretWord.Text = presenter.update();
                }
                
            }
        }

       
        private void categoryItemChanged(object sender, EventArgs e)
        {
            if (sender is DomainUpDown b)
            {

                presenter = new GamePresenter(b.SelectedIndex);
                lblSecretWord.Text = presenter.update();
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (sender is ComboBox c)
            {
                presenter = new GamePresenter(c.SelectedIndex);
                string selectedWord = presenter.Start(); 

                if (selectedWord != null)
                {
                    lblSecretWord.Text = new string('_', selectedWord.Length).Replace("", " ").Trim();
                }
                else
                {
                    MessageBox.Show("No word found for the selected category.");
                }
            }
        }
    }
}
