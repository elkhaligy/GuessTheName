using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Presenters
{
    public class GamePresenter
    {
        public Game myGame {  get; private set ; }

        public string secretWord { get; set; }

        public enum PlayerTurn { Player1, Player2 }
        public PlayerTurn CurrentPlayer { get; private set; } = PlayerTurn.Player1;
        public PlayerTurn Winner { get; private set; }
    

        private HashSet<char> guessedLetters = new HashSet<char>();


        public GamePresenter()
        {
            secretWord = string.Empty;
        }
        public GamePresenter(int _category)
        {
            myGame = new Game((Category) _category);
            secretWord = myGame.StartGame();

        }

        public GamePresenter( string category)
        {
            //        secretWord = myGame.StartGame(); 
            myGame = new Game(category.GetCategory());
          //  secretWord = myGame.StartGame();
        }
      
       

        public bool CHECK(char letter)
        {

            if (myGame.isFinished) return false;
            letter = char.ToLower(letter);
            bool isNewGuess = guessedLetters.Add(letter);
            bool isCorrect = secretWord.ToLower().Contains(letter);

            if (!isCorrect)
            {
                if (CurrentPlayer == PlayerTurn.Player1)
                {
                    CurrentPlayer = PlayerTurn.Player2;
                }
                else
                {
                    CurrentPlayer = PlayerTurn.Player1;
                }
            }
            else if (isNewGuess)
            {
               
                if (secretWord.All(c => guessedLetters.Contains(char.ToLower(c))))
                {
                   myGame.isFinished = true;
                    Winner = CurrentPlayer;

                   
                }
            }

            return isCorrect;
        }
        public string update()
        {
            StringBuilder revealedWord = new StringBuilder();
            foreach (char letter in secretWord)
            {
                if (guessedLetters.Contains(char.ToLower(letter)))
                {
                    revealedWord.Append(letter + " ");

                }
                else
                {
                    revealedWord.Append("_ "); 
                }
            }
            return revealedWord.ToString().Trim(); 
        }
        public string update(List<char> revealedLetters)
        {
            StringBuilder revealedWord = new StringBuilder();
            foreach (char letter in secretWord)
            {
                if (revealedLetters.Contains(char.ToLower(letter)))
                {
                    revealedWord.Append(letter + " ");

                }
                else
                {
                    revealedWord.Append("_ ");
                }
            }
            return revealedWord.ToString().Trim();
        }

       // public void RestartGame()
        //{
       
            //secretWord = myGame.StartGame();
           // guessedLetters.Clear();
           // myGame.isFinished = false;
            //CurrentPlayer = PlayerTurn.Player1;
      //  }




        public void Start()
        {
            secretWord = myGame.StartGame(); // game when start return random word
            guessedLetters.Clear();
            myGame.isFinished = false;
            CurrentPlayer = PlayerTurn.Player1;
            Winner = PlayerTurn.Player1;
        }
    }
}
