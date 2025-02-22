

using ClientApp.Presenters;

namespace ClientApp.Views
{
    public partial class GameForm : Form
    {
        public GamePresenter presenter { private set; get; }
        private string selectedWord;
        public event EventHandler<HashSet<char>> OnReveal;

        public GameForm(GamePresenter _presenter, string playerName)
        {
            InitializeComponent();
            this.KeyPreview = true;
            presenter = _presenter;
            //lblSecretWord.Visible = false;
            selectedWord = presenter.secretWord;
            lblSecretWord.Text = new string('_', selectedWord.Length).Replace("_", "\u2500  ");
            this.KeyPress += keyPressed;
            label1.Text += playerName;
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
            bool correct = presenter.CHECK(pressedLetter);
            if (correct)
            {
                lblSecretWord.Text = presenter.update();
                if (OnReveal != null)
                {
                    OnReveal(this, presenter.guessedLetters);
                }
            }
        }


        private void letterClicked(object sender, EventArgs e)
        {
            if (presenter.isFinished || presenter == null) return;

         
            if (sender is Button b)
            {

                char guessedLetter = b.Text[0];
                bool correct = presenter.CHECK(guessedLetter);
                b.Enabled = false;
                if (correct)
                {
                    lblSecretWord.Text = presenter.update();
                    if (OnReveal != null)
                    {
                        OnReveal(this, presenter.guessedLetters);
                    }
                }

                if (presenter.isFinished)
                {
                    string winner, loser; 
                    if (presenter.Winner == GamePresenter.PlayerTurn.Player1)
                    {
                        winner = "Player 1" ;
                        loser = "Player 2";
                    }
                    else
                    {
                        winner = "Player 2";
                        loser = "Player 1";
                    }
                    
                    
                    DialogResult result = MessageBox.Show(
                        $"{winner} wins! Congratulations!\n{loser} loses. Sorry!\n\nPlay again?",
                        "Game Over",
                        MessageBoxButtons.YesNo
                    );

                    if (result == DialogResult.Yes)
                    {
                       // presenter.RestartGame();
                     
                    }
                    else
                    {
                        this.Close();
                    }
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


    }
}



