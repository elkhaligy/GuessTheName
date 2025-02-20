﻿using Shared.Enums;
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
        Game myGame {  get; set; }

        public string secretWord { get; set; }

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
      
        private HashSet<char> guessedLetters = new HashSet<char>();

        public bool CHECK(char letter)
        {
            letter = char.ToLower(letter);
            guessedLetters.Add(letter);
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



        public void Start()
        {
            secretWord = myGame.StartGame(); // game when start return random word
        }
    }
}
