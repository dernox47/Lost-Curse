using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class PressEnter
    {
        public PressEnter() {}

        public void ToContinue()
        {
        GetInput:
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Enter:
                    return;
                default:
                    goto GetInput;
            }
        }
    }
}
