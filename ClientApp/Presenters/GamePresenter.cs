using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Presenters
{
    internal class GamePresenter
    {
        Game myGame {  get; set; }

        public GamePresenter(int _category)
        {
            myGame = new Game((Category) _category);
            
        }


        public string secretWord = "COMPUTER";
        private HashSet<char> guessedLetters = new HashSet<char>();

        public bool CHECK(char letter)
        {

            letter = char.ToUpper(letter);

            return secretWord.Contains(letter);
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

        public string Start()
        {
            return myGame.StartGame(); 
        }
    }
}
