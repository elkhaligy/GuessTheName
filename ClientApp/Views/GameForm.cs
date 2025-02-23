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
        //private GamePresenter.PlayerTurn myPlayer;
        public string currentPlayer;
        //private static List<GameForm> allGameForms = new List<GameForm>();

        public event EventHandler<HashSet<char>> OnReveal;
        public event EventHandler<string> OnSwitchPlayer;

        public GameForm(GamePresenter _presenter, string playerName)
        {
            InitializeComponent();
            this.KeyPreview = true;
            presenter = _presenter;
           // myPlayer = player;
            currentPlayer = playerName;
            //allGameForms.Add(this);

            selectedWord = presenter.secretWord;
            lblSecretWord.Text = new string('_', selectedWord.Length).Replace("_", "\u2500  ");
            this.KeyPress += keyPressed;
            label1.Text = "Player: " + playerName;

            //UpdateAllButtonStates();
        }

        protected override void OnClosed(EventArgs e)
        {
            //allGameForms.Remove(this);
            base.OnClosed(e);
        }

        public void viewRevealedLetters()
        {
            lblSecretWord.Text = presenter.update();
        }

        public void keyPressed(object? sender, KeyPressEventArgs e)
        {
            if (presenter == null) return;

            char pressedLetter = char.ToLower(e.KeyChar);
            if (!char.IsLetter(pressedLetter)) return;

            //if (myPlayer != presenter.CurrentPlayer)
            //{
            //    MessageBox.Show("It is not your turn.");
            //    return;
            //}

            //if (presenter.blockedPlayer == myPlayer)
            //{
            //    MessageBox.Show("You are temporarily disabled. Wait for the other player to make a wrong guess.");
            //    return;
            //}

            bool correct = presenter.CHECK(pressedLetter, currentPlayer);
            if(correct)
                DisableButton(pressedLetter);
            else
            {
                DisablePlayer();
            }
            lblSecretWord.Text = presenter.update();
            OnReveal?.Invoke(this, presenter.guessedLetters);

            //UpdateAllButtonStates();

            if (presenter.isFinished)
            {
                ShowGameOverMessages();
            }
        }

        private void DisablePlayer()
        {
            foreach (Control c in this.Controls) //
            {
                c.Enabled = false;
            }
            this.KeyPress -= keyPressed;
            OnSwitchPlayer?.Invoke(this, currentPlayer);
        }

        private void letterClicked(object sender, EventArgs e)
        {
            if (presenter.isFinished || presenter == null) return;
            if (sender is Button b)
            {
                //if (myPlayer != presenter.CurrentPlayer)
                //{
                //    MessageBox.Show("It is not your turn.");
                //    return;
                //}

                //if (presenter.blockedPlayer == myPlayer)
                //{
                //    MessageBox.Show("You are temporarily disabled. Wait for the other player to make a wrong guess.");
                //    return;
                //}

                char guessedLetter = char.ToLower(b.Text[0]);
                bool correct = presenter.CHECK(guessedLetter, currentPlayer);
                if (!correct)
                {
                    DisablePlayer();
                }
                else
                {
                    b.Enabled = false;
                    this.KeyPress += keyPressed;
                }
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
                if (control is Button btn && char.ToLower(btn.Text[0]) == letter)
                {
                    btn.Enabled = false;
                }
            }
        }

        private void UpdateButtonStates()
        {
            HashSet<char> revealLetters = presenter.guessedLetters;
            foreach (Control control in this.Controls)
            {
                if (control is Button btn && revealLetters.Contains(btn.Text[0]))
                {
                        btn.Enabled = false;
                }
            }
        }

        private void UpdateAllButtonStates()
        {
            UpdateButtonStates();
        }

        private void ShowGameOverMessages()
        {
            string message;
            if (currentPlayer == presenter.WinnerName)
            {
                message = $"Congratulations, {label1.Text}, you are the winner!\nPlay again?";
            }
            else
            {
                message = $"Sorry, {label1.Text}, you lost!\nPlay again?";
            }
            DialogResult result = MessageBox.Show(this, message, "Game Over", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                presenter.RestartGame();

                ResetUI();
            }
            else
            {
                this.Close();
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
    }
}