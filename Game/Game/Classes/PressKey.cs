using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class PressKey
    {
        public PressKey() {}

        public void Enter()
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

        public void E()
        {
        GetInput:
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.E:
                    return;
                default:
                    goto GetInput;
            }
        }

        public void Escape()
        {
        GetInput:
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Escape:
                    return;
                default:
                    goto GetInput;
            }
        }
    }
}
