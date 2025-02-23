using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientApp.Presenters
{
    public class GamePresenter
    {
        public Game myGame { get; private set; }
        public string secretWord { get; set; }

        public enum PlayerTurn { Player1, Player2 }
        public bool isFinished { get; set; } = false;
        public PlayerTurn CurrentPlayer { get; set; } = PlayerTurn.Player1;
        public string WinnerName { get; private set; }
        public PlayerTurn? blockedPlayer { get; set; } = null;  // Changed to public setter

        public event EventHandler? TurnChanged;
        public HashSet<char> guessedLetters = new HashSet<char>();
        public GamePresenter()
        {
            secretWord = string.Empty;
        }

        public GamePresenter(string category)
        {
            myGame = new Game(category.GetCategory());
        }

        public bool CHECK(char letter, string currentPlayer)
        {
            if (isFinished) return false;

            letter = char.ToLower(letter);
            bool isNewGuess = guessedLetters.Add(letter);
            bool isCorrect = secretWord.ToLower().Contains(letter);

            if (!isCorrect)
            {
                blockedPlayer = CurrentPlayer;
                CurrentPlayer = (CurrentPlayer == PlayerTurn.Player1) ? PlayerTurn.Player2 : PlayerTurn.Player1;
                TurnChanged?.Invoke(this, EventArgs.Empty);
            }
            else if (isNewGuess)
            {
                if (secretWord.All(c => guessedLetters.Contains(char.ToLower(c))))
                {
                    isFinished = true;
                    WinnerName = currentPlayer;
                }
            }

            return isCorrect;
        }

        public string update()
        {
            StringBuilder revealedWord = new StringBuilder();
            foreach (char letter in secretWord)
            {
                revealedWord.Append(guessedLetters.Contains(char.ToLower(letter)) ? $"{letter} " : "_ ");
            }
            return revealedWord.ToString().Trim();
        }

        public void RestartGame()
        {
            secretWord = myGame.StartGame();
            guessedLetters.Clear();
            isFinished = false;
            CurrentPlayer = PlayerTurn.Player1;
            //WinnerName = PlayerTurn.Player1;
            blockedPlayer = null;
            TurnChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Start()
        {
            secretWord = myGame.StartGame();
            guessedLetters.Clear();
            isFinished = false;
            CurrentPlayer = PlayerTurn.Player1;
            //Winner = PlayerTurn.Player1;
            blockedPlayer = null;
        }
    }
}