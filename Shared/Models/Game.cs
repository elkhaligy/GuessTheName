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
            string filePath = $"D:/ITI/Visual C#/Project/GuessTheName/Shared/Data/{category}.txt";
            Random random = new Random();
            if (File.Exists(filePath))
            {
                List<string> randomNames = File.ReadLines(filePath).ToList();
                using (BinaryReader br = new BinaryReader(File.Open(filePath,
                                         FileMode.Open), Encoding.UTF8))
                {
                    //Reads the data to the stream
                    int r = random.Next(randomNames.Count()) ;
                    return randomNames[r];
                }
            }
            return null;
        }
    }
}
