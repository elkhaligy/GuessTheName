﻿

using ClientApp.Presenters;

namespace ClientApp.Views
{
    public partial class GameForm : Form
    {
        private GamePresenter presenter;
        private string selectedWord;

        public GameForm(GamePresenter _presenter)
        {
            InitializeComponent();
            this.KeyPreview = true;
            presenter = _presenter;
            //lblSecretWord.Visible = false;
            selectedWord = presenter.secretWord;
            lblSecretWord.Text = new string('_', selectedWord.Length).Replace("_", "\u2500  ");
            this.KeyPress += keyPressed;
        }

        private void keyPressed(object? sender, KeyPressEventArgs e)
        {
            if (presenter == null) return;

            char pressedLetter = char.ToUpper(e.KeyChar);
            if (!char.IsLetter(pressedLetter)) return;
            foreach (Control control in this.Controls)
            {

                if (control is Button btn && btn.Text == pressedLetter.ToString())
                {

                    if (btn.Enabled)
                    {
                        letterClicked(btn, EventArgs.Empty);
                    }
                    break;
                }
            }
            e.Handled = true;
        }


        private void letterClicked(object sender, EventArgs e)
        {

            if (presenter == null) return;
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

                //presenter = new GamePresenter(b.SelectedIndex);
                lblSecretWord.Text = presenter.update();
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (sender is ComboBox c)
            {
                //presenter = new GamePresenter(c.SelectedIndex);

                if (selectedWord != null)
                {
                    lblSecretWord.Visible = true;
                    lblSecretWord.Text = new string('_', selectedWord.Length).Replace("_", "\u2500  ");
                }
                else
                {
                    MessageBox.Show("No word found for the selected category.");
                }
            }
        }
    }
}
