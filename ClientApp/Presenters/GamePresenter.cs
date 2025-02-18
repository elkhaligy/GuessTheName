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
        public string Start()
        {
            return myGame.StartGame(); 
        }
    }
}
