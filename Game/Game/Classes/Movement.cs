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

        private int shopX;
        private int shopY;

        private char[,] originalMap;
        private char[,] currentMap;
        private char[] forbiddenChars = new char[] { '=', ']', '['};

        private bool collision;

        public bool Collision
        {
            get { return collision; }
            private set
            {
                if (posX == enemyX - 2)
                {
                    collision = true;
                }
                else collision = false;
            }
        }



        public Movement(string fileName)
        {
            ReadMap(fileName);
            Find();
            DrawChar();
            DrawEnemy();
        }

        public void StartMap(Battle battle)
        {
            while (true)
            {
                Console.CursorVisible = false;

                DrawMap();

                if (!battle._enemyDefeated)
                {
                    Collision = false;
                }

                if (collision)
                {
                    battle.Begin();
                    if (battle._enemyDefeated)
                    {
                        RemoveEnemy();
                        collision = false;
                        DrawChar();
                        DrawShop();
                    }
                }

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
                Console.Clear();

                
            }
        }

        //Pálya beolvasása, eltárolása
        private void ReadMap(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            int width = lines[0].Length;
            int height = lines.Length;

            currentMap = new char[width, height];
            originalMap = new char[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    currentMap[x, y] = lines[y][x];
                    originalMap[x, y] = lines[y][x];
                }
            }
        }

        //Indexek megkeresése a pályán és elmentése
        private void Find()
        {
            for (int y = 0; y < originalMap.GetLength(1); y++)
            {
                for (int x = 0; x < originalMap.GetLength(0); x++)
                {
                    if (originalMap[x, y] == 'x')
                    {
                        posX = x;
                        posY = y;
                    }
                    else if (originalMap[x, y] == 'e')
                    {
                        enemyX = x;
                        enemyY = y;
                    }
                    else if (originalMap[x, y] == 's')
                    {
                        shopX = x;
                        shopY = y;
                        currentMap[x, y] = ' ';
                    }
                }
            }
        }

        //Pálya kiíratása
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


        //Objektek kiíratása vagy eltüntetése
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

        private void RemoveEnemy()
        {
            currentMap[enemyX, enemyY] = ' ';

            currentMap[enemyX, enemyY + 1] = ' ';
            currentMap[enemyX - 1, enemyY + 1] = ' ';
            currentMap[enemyX + 1, enemyY + 1] = ' ';

            currentMap[enemyX, enemyY + 2] = ' ';
            currentMap[enemyX - 1, enemyY + 2] = ' ';
            currentMap[enemyX + 1, enemyY + 2] = ' ';
        }

        // _/_\_
        // |_°_|
        // |___|

        private void DrawShop()
        {
            currentMap[shopX, shopY] = '_';
            currentMap[shopX - 1, shopY] = '/';
            currentMap[shopX - 2, shopY] = '_';
            currentMap[shopX + 1, shopY] = '\\';
            currentMap[shopX + 2, shopY] = '_';

            currentMap[shopX, shopY + 1] = '°';
            currentMap[shopX - 1, shopY + 1] = '_';
            currentMap[shopX - 2, shopY + 1] = '|';
            currentMap[shopX + 1, shopY + 1] = '_';
            currentMap[shopX + 2, shopY + 1] = '|';

            currentMap[shopX, shopY + 2] = '_';
            currentMap[shopX - 1, shopY + 2] = '_';
            currentMap[shopX - 2, shopY + 2] = '|';
            currentMap[shopX + 1, shopY + 2] = '_';
            currentMap[shopX + 2, shopY + 2] = '|';
        }

        private void RemoveShop()
        {
            currentMap[shopX, shopY] = ' ';
            currentMap[shopX - 1, shopY] = ' ';
            currentMap[shopX - 2, shopY] = ' ';
            currentMap[shopX + 1, shopY] = ' ';
            currentMap[shopX + 2, shopY] = ' ';

            currentMap[shopX, shopY + 1] = ' ';
            currentMap[shopX - 1, shopY + 1] = ' ';
            currentMap[shopX - 2, shopY + 1] = ' ';
            currentMap[shopX + 1, shopY + 1] = ' ';
            currentMap[shopX + 2, shopY + 1] = ' ';

            currentMap[shopX, shopY + 2] = ' ';
            currentMap[shopX - 1, shopY + 2] = ' ';
            currentMap[shopX - 2, shopY + 2] = ' ';
            currentMap[shopX + 1, shopY + 2] = ' ';
            currentMap[shopX + 2, shopY + 2] = ' ';
        }


        //Mozgás lekezelések
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
    }
}