using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Other;

namespace Game.Classes
{
    class MainGame : IGame
    {
        public void Start()
        {
            Console.WriteLine("Lost Curse\n");
        }

        public void End()
        {
            Console.WriteLine("Bye.");
        }
    }
}
