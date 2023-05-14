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
        private static string title = @"
  _              _      ____                    
 | |    ___  ___| |_   / ___|   _ _ __ ___  ___ 
 | |   / _ \/ __| __| | |  | | | | '__/ __|/ _ \
 | |__| (_) \__ \ |_  | |__| |_| | |  \__ \  __/
 |_____\___/|___/\__|  \____\__,_|_|  |___/\___|
                                                
";

        public void Start()
        {
            Console.WriteLine(title);
            Console.Write("Enter your character's name: ");
            string name = Console.ReadLine();


            Console.Clear();

            Player player = new Player(name);
            TextHandler story = new TextHandler("storyTexts.txt");

            story.Print("BackgroundStory");
            story.Print("GuildStart");

            //Guild teszt kérdések




            Movement movement;
            movement = new Movement("mapGuildTest.txt");
            Enemy enemy = new Enemy("Adventurer", 80, 80, 10, 0, 1, 0, 0);


            movement.Collision += (sender, e) =>
            {
                Battle battleTest = new Battle(player, enemy);

                battleTest.Begin();
            };

            movement.Update();

            //Győzelem után








            //Első küldetés kiválasztás






            //Küldetés leírás







            //




        }

        public void End()
        {
            Console.WriteLine("Bye.");
        }
    }
}
