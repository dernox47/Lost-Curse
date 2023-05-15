using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game.Classes
{
    class Movement
    {
        private int posX;
        private int posY;
        private int enemyX;
        private int enemyY;
        private char[,] currentMap;
        private char[] forbiddenChars = new char[] { '=', ']', '['};
        public event EventHandler Collision;

        public Movement(string fileName)
        {
            ReadMap(fileName);
            Find();
            DrawChar();
            DrawEnemy();
        }

        private void ReadMap(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            int width = lines[0].Length;
            int height = lines.Length;

            currentMap = new char[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    currentMap[x, y] = lines[y][x];
                }
            }
        }

        private void Find()
        {
            for (int y = 0; y < currentMap.GetLength(1); y++)
            {
                for (int x = 0; x < currentMap.GetLength(0); x++)
                {
                    if (currentMap[x, y] == 'x')
                    {
                        posX = x;
                        posY = y;
                    }
                    else if (currentMap[x, y] == 'e')
                    {
                        enemyX = x;
                        enemyY = y;
                    }
                }
            }
        }

        public void DrawMap()
        {
            for (int y = 0; y < currentMap.GetLength(1); y++)
            {
                for (int x = 0; x < currentMap.GetLength(0); x++)
                {
                    Console.Write(currentMap[x, y]);
                }
                Console.WriteLine();
            }
        }

        private void DrawChar()
        {
            currentMap[posX, posY] = 'o';

            currentMap[posX, posY + 1] = '|';
            currentMap[posX - 1, posY + 1] = '/';
            currentMap[posX + 1, posY + 1] = '\\';

            currentMap[posX, posY + 2] = ' ';
            currentMap[posX - 1, posY + 2] = '/';
            currentMap[posX + 1, posY + 2] = '\\';
        }
        private void RemoveChar()
        {
            currentMap[posX, posY] = ' ';

            currentMap[posX, posY + 1] = ' ';
            currentMap[posX - 1, posY + 1] = ' ';
            currentMap[posX + 1, posY + 1] = ' ';

            currentMap[posX, posY + 2] = ' ';
            currentMap[posX - 1, posY + 2] = ' ';
            currentMap[posX + 1, posY + 2] = ' ';
        }

        private void DrawEnemy()
        {
            currentMap[enemyX, enemyY] = '°';

            currentMap[enemyX, enemyY + 1] = 'O';
            currentMap[enemyX - 1, enemyY + 1] = '/';
            currentMap[enemyX + 1, enemyY + 1] = '\\';

            currentMap[enemyX, enemyY + 2] = ' ';
            currentMap[enemyX - 1, enemyY + 2] = '/';
            currentMap[enemyX + 1, enemyY + 2] = '\\';
        }

        private bool Collide()
        {
            if (posX == enemyX - 2)
            {
                return true;
            }
            return false;
        }

        private void CollisionHandle()
        {
            if (Collide())
            {
                Collision?.Invoke(this, EventArgs.Empty);
            }
        }



        public void MoveLeft()
        {
            if (forbiddenChars.Contains(currentMap[posX - 2, posY]) == false)
            {
                RemoveChar();
                posX--;
                DrawChar();
            }
        }

        public void MoveRight()
        {
            if (forbiddenChars.Contains(currentMap[posX + 2, posY]) == false)
            {
                RemoveChar();
                posX++;
                DrawChar();
            }
        }

        public void MoveUp()
        {
            if (forbiddenChars.Contains(currentMap[posX, posY - 1]) == false)
            {
                RemoveChar();
                posY--;
                DrawChar();
            }
        }

        public void MoveDown()
        {
            if (forbiddenChars.Contains(currentMap[posX, posY + 3]) == false)
            {
                RemoveChar();
                posY++;
                DrawChar();
            }
        }




        public void Update()
        {
            while (true)
            {
                Console.CursorVisible = false;

                DrawMap();

                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);

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
                CollisionHandle();
                Console.Clear();
            }
        }
    }
}