using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game.Classes
{
    class TextHandler
    {
        private Dictionary<string, string[]> texts = new Dictionary<string, string[]>();

        public TextHandler(string fileName)
        {
            if (File.Exists(fileName))
            {
                string fileText = File.ReadAllText(fileName);
                string[] blocks = fileText.Split('#', (char)StringSplitOptions.RemoveEmptyEntries);

                foreach (string block in blocks)
                {
                    string[] stringSeparators = new string[] { "\r\n" };
                    string[] titleAndLines = block.Split('@');
                    string title = titleAndLines[0].Trim();
                    string[] lines = titleAndLines[1].Trim().Split(stringSeparators, StringSplitOptions.None);

                    texts.Add(title, lines);
                }
            }
            else
            {
                Console.WriteLine("The file does not exists.");
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public void Print(string blockName)
        {
            Console.CursorVisible = false;
            
            
            foreach (string line in texts[blockName])
            {
                const int width = 80;

                string[] words = line.Split(' ');

                int remainingWidth = width;
                foreach (string word in words)
                {
                    if (word.Length > remainingWidth)
                    {
                        Console.WriteLine();
                        Console.Write(word + " ");
                        remainingWidth = width - word.Length - 1;
                    }
                    else
                    {
                        Console.Write(word + " ");
                        remainingWidth -= word.Length + 1;
                        if (remainingWidth < 0)
                        {
                            Console.WriteLine();
                            remainingWidth = width;
                        }
                    }
                }
                Console.WriteLine();

                Console.ReadLine();
            }
        }

    }
}
