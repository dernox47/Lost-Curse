using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Classes.Items;
using Game.Interfaces.Items;
using Game.Interfaces.Other;

namespace Game.Classes
{
    class MainGame : IGame
    {
        static PressEnter pressEnter = new PressEnter();

        private bool playing = true;

        private static string title = @"
  _              _      ____                    
 | |    ___  ___| |_   / ___|   _ _ __ ___  ___ 
 | |   / _ \/ __| __| | |  | | | | '__/ __|/ _ \
 | |__| (_) \__ \ |_  | |__| |_| | |  \__ \  __/
 |_____\___/|___/\__|  \____\__,_|_|  |___/\___|
                                                
";

        public void Start()
        {
            while (playing)
            {
                Console.WriteLine(title);
                Console.Write("Enter your character's name: ");
                string name = Console.ReadLine();


                Console.Clear();

                Player player = new Player(name);
                TextHandler story = new TextHandler("storyTexts.txt");

                //story.Print("BackgroundStory");
                //story.Print("GuildStart");

                //Guild teszt kérdések
                bool allAnswerCorrect = false;

                //while (!allAnswerCorrect)
                //{
                //    Console.CursorVisible = false;

                //    Console.WriteLine("The first question is:");
                //    Console.WriteLine("What is the slimes weakness?\n");
                //    Console.WriteLine("1. water");
                //    Console.WriteLine("2. sword");
                //    Console.WriteLine("3. fire");

                //    int firstQuestion = GetInput(3);

                //    if (firstQuestion == 3)
                //    {
                //        Console.WriteLine("\nSlimes are weak against fire and can easily burn but water or swords can only damage it a little.");
                //    }
                //    Console.WriteLine("\nPress [enter] to continue...");
                //    pressEnter.ToContinue();
                //    Console.Clear();

                //    Console.WriteLine("The second question is:");
                //    Console.WriteLine("Which monsters kill the most new adventurers?\n");
                //    Console.WriteLine("1. slime");
                //    Console.WriteLine("2. wolf");
                //    Console.WriteLine("3. goblin");

                //    int secondQuestion = GetInput(3);

                //    if (secondQuestion == 3)
                //    {
                //        Console.WriteLine("\nGoblins are very cunning creatures that lay traps and attack when the adventurers don't expect it.");
                //    }
                //    Console.WriteLine("\nPress [enter] to continue...");
                //    pressEnter.ToContinue();
                //    Console.Clear();

                //    Console.WriteLine("The third question is:");
                //    Console.WriteLine("What should you do when you face a monster that you can't beat?\n");
                //    Console.WriteLine("1. run away");
                //    Console.WriteLine("2. back off while watching the enemy");
                //    Console.WriteLine("3. try to hide");

                //    int thirdQuestion = GetInput(3);

                //    if (thirdQuestion == 2)
                //    {
                //        Console.WriteLine("\nWhen fighting a strong monster you shouldn't show your back and you should escape while watching it.");
                //    }
                //    Console.WriteLine("\nPress [enter] to continue...");
                //    pressEnter.ToContinue();
                //    Console.Clear();

                //    if (firstQuestion == 3 && secondQuestion == 3 && thirdQuestion == 2)
                //    {
                //        Console.WriteLine("Congratulation! You passed the test.");
                //        allAnswerCorrect = true;
                //        pressEnter.ToContinue();
                //    }
                //    else
                //    {
                //        Console.WriteLine("You failed the test, please try again.");
                //        Console.WriteLine("\nPress [enter] to continue...");
                //        pressEnter.ToContinue();
                //    }
                //    Console.Clear();
                //}

                //story.Print("BeforeGuildFight");


                Apple apple = new Apple();
                Bread bread = new Bread();
                Bread bread1 = new Bread();
                Bread bread2 = new Bread();
                Bread bread3 = new Bread();
                Bread bread4 = new Bread();
                HpPotion hpPotion = new HpPotion();

                Dictionary<IItem, int> initialStockGuild = new Dictionary<IItem, int>()
                {
                    { apple, 5 },
                    { bread, 6 },
                    { bread1, 6 },
                    { bread2, 6 },
                    //{ bread3, 6 },
                    //{ bread4, 6 },
                    //{ hpPotion, 4 }
                };

                Shop guildShop = new Shop(initialStockGuild, player);

                Movement movement;
                movement = new Movement("mapGuildTest.txt");
                Enemy enemy = new Enemy("Adventurer", 10, 80, 10, 0, 1, 10, 0);
                Battle adventurerBattle = new Battle(player, enemy);


                movement.StartMap(adventurerBattle, guildShop);




                //Győzelem után








                //Első küldetés kiválasztás






                //Küldetés leírás







                //




            }
        }

        public void End()
        {
            Console.WriteLine("Bye.");
        }

        private int GetInput(int maxChoice)
        {
            int choice;

            do
            {
                Console.Write($"Enter your choice (1-{maxChoice}): ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxChoice);

            return choice;

        }
    }
}
