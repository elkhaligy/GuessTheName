using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Game
    {
        public Guid Id { get; private set; }
        public Category category { get; set; }
        public bool isFinished { get; set; } = false;

        public Game(Category _category)
        {
            category = _category;
            Id = Guid.NewGuid();
        }




        public string StartGame()
        {
         
            string filePath = $"C:/Game/GuessTheName/Shared/Data/{category}.txt";
            Random random = new Random();
            if (File.Exists(filePath))
            {
             
                List<string> randomNames = File.ReadAllLines(filePath).ToList();
                if (randomNames.Count > 0)
                {
                    int randomIndex = random.Next(randomNames.Count);
                    return randomNames[randomIndex]; 
                }
            }

            return null;
        }
    }
}
