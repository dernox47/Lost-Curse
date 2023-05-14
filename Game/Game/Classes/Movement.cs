using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class Movement
    {
        public int x;
        public int y;

        public Movement(int x, int y)
        {
            this.x = x;
            this.y = y;
            Draw();
            Update();
            Console.Clear();
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(@" o ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine(@"/|\");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine(@"/ \");
        }
        public void Remove()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(@"   ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine(@"   ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine(@"   ");
        }

        public void Update()
        {
            while (true)
            {
                Console.CursorVisible = false;

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        MoveRight();
                        break;
                    case ConsoleKey.UpArrow:
                        MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveDown();
                        break;
                }
            }
        }

        public void MoveLeft()
        {
            if (x > 0)
            {
                Remove();
                x -= 2;
                Draw();
            }
        }

        public void MoveRight()
        {
            if (x < Console.WindowWidth - 4)
            {
                Remove();
                x += 2;
                Draw();
            }
        }

        public void MoveUp()
        {
            if (y > 0)
            {
                Remove();
                y--;
                Draw();
            }
        }

        public void MoveDown()
        {
            if (y < Console.WindowHeight - 4)
            {
                Remove();
                y++;
                Draw();
            }
        }
    }
}