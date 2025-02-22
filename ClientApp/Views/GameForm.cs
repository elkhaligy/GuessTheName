using ClientApp.Presenters;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientApp.Views
{
    public partial class GameForm : Form
    {
        public GamePresenter presenter { get; private set; }
        private string selectedWord;
        private GamePresenter.PlayerTurn myPlayer;
        private static List<GameForm> allGameForms = new List<GameForm>();

        public event EventHandler<HashSet<char>> OnReveal;

        public GameForm(GamePresenter _presenter, string playerName, GamePresenter.PlayerTurn player)
        {
            InitializeComponent();
            this.KeyPreview = true;
            presenter = _presenter;
            myPlayer = player;
            allGameForms.Add(this);

            selectedWord = presenter.secretWord;
            lblSecretWord.Text = new string('_', selectedWord.Length).Replace("_", "\u2500  ");
            this.KeyPress += keyPressed;
            label1.Text = "Player: " + playerName;

            UpdateAllButtonStates();
        }

        protected override void OnClosed(EventArgs e)
        {
            allGameForms.Remove(this);
            base.OnClosed(e);
        }

        public void viewRevealedLetters()
        {
            lblSecretWord.Text = presenter.update();
        }

        private void keyPressed(object? sender, KeyPressEventArgs e)
        {
            if (presenter == null) return;

            char pressedLetter = char.ToLower(e.KeyChar);
            if (!char.IsLetter(pressedLetter)) return;

            if (myPlayer != presenter.CurrentPlayer)
            {
                MessageBox.Show("It is not your turn.");
                return;
            }

            if (presenter.blockedPlayer == myPlayer)
            {
                MessageBox.Show("You are temporarily disabled. Wait for the other player to make a wrong guess.");
                return;
            }

            bool correct = presenter.CHECK(pressedLetter);
            DisableButton(pressedLetter);
            lblSecretWord.Text = presenter.update();
            OnReveal?.Invoke(this, presenter.guessedLetters);

            UpdateAllButtonStates();

            if (presenter.isFinished)
            {
                ShowGameOverMessages();
            }
        }

        private void letterClicked(object sender, EventArgs e)
        {
            if (presenter.isFinished || presenter == null) return;
            if (sender is Button b)
            {
                if (myPlayer != presenter.CurrentPlayer)
                {
                    MessageBox.Show("It is not your turn.");
                    return;
                }

                if (presenter.blockedPlayer == myPlayer)
                {
                    MessageBox.Show("You are temporarily disabled. Wait for the other player to make a wrong guess.");
                    return;
                }

                char guessedLetter = char.ToLower(b.Text[0]);
                bool correct = presenter.CHECK(guessedLetter);
                b.Enabled = false;
                lblSecretWord.Text = presenter.update();
                OnReveal?.Invoke(this, presenter.guessedLetters);
                UpdateAllButtonStates();

                if (presenter.isFinished)
                {
                    ShowGameOverMessages();
                }
            }
        }

        private void DisableButton(char letter)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Tag?.ToString() == "letter" && char.ToLower(btn.Text[0]) == letter)
                {
                    btn.Enabled = false;
                }
            }
        }

        private void UpdateButtonStates()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Tag?.ToString() == "letter")
                {
                    char letter = char.ToLower(btn.Text[0]);
                    if (presenter.guessedLetters.Contains(letter))
                    {
                        btn.Enabled = false;
                    }
                    else
                    {
                        btn.Enabled = (myPlayer == presenter.CurrentPlayer && presenter.blockedPlayer != myPlayer);
                    }
                }
            }
        }

        private void UpdateAllButtonStates()
        {
            foreach (GameForm form in allGameForms)
            {
                form.UpdateButtonStates();
            }
        }

        private void ShowGameOverMessages()
        {
            foreach (GameForm form in allGameForms)
            {
                string message;
                if (form.myPlayer == presenter.Winner)
                {
                    message = $"Congratulations, {form.label1.Text}, you are the winner!\nPlay again?";
                }
                else
                {
                    message = $"Sorry, {form.label1.Text}, you lost!\nPlay again?";
                }
                DialogResult result = MessageBox.Show(form, message, "Game Over", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    presenter.RestartGame();
                    foreach (GameForm f in allGameForms)
                    {
                        f.ResetUI();
                    }
                }
                else
                {
                    form.Close();
                }
            }
        }

        private void ResetUI()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Tag?.ToString() == "letter")
                {
                    btn.Enabled = true;
                }
            }
            selectedWord = presenter.secretWord;
            lblSecretWord.Text = new string('_', selectedWord.Length).Replace("_", "\u2500  ");
            UpdateAllButtonStates();
        }

        private void categoryItemChanged(object sender, EventArgs e)
        {
            if (sender is DomainUpDown b)
            {
                lblSecretWord.Text = presenter.update();
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (sender is ComboBox c)
            {
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