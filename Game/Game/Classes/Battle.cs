using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Other;
using Game.Classes.Items;

namespace Game.Classes
{
    class Battle
    {
        private Player _player { get; set; }
        private Enemy _enemy { get; set; }
        private bool _isPlayerTurn;
        private bool _isBattleOver;

        public Battle(Player player, Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
            _isPlayerTurn = true;
            _isBattleOver = false;
        }

        public void Begin()
        {
            Console.Clear();
            Console.WriteLine($"A(n) {_enemy.Name} appeared.\n");
            Console.WriteLine($"{_player.Name} ({_player.Hp}/{_player.MaxHp})\t{_enemy.Name} ({_enemy.Hp}/{_enemy.MaxHp})\n", Console.ForegroundColor = ConsoleColor.Red);
            Console.ResetColor();
            Console.WriteLine("Press [enter] to start the fight...");

            PressEnterToContinue();

            while (!_isBattleOver)
            {
                if (_isPlayerTurn)
                {
                    Console.Clear();
                    Console.WriteLine($"{_player.Name} ({_player.Hp}/{_player.MaxHp})\t{_enemy.Name} ({_enemy.Hp}/{_enemy.MaxHp})\n", Console.ForegroundColor = ConsoleColor.Red);
                    Console.ResetColor();
                    PlayerTurn();
                }
                else
                {
                    EnemyTurn();
                }

                _isPlayerTurn = !_isPlayerTurn;

            }
        }

        private void PlayerTurn()
        {
            Console.WriteLine("It is your turn:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Heal");
            Console.WriteLine("3. Give up");

            int choice = GetInput(3);



            switch (choice)
            {
                case 1:
                    _player.Attack(_enemy);
                    Console.WriteLine($"\nYou damaged: {_player.Atk}.\n");
                    break;
                case 2:
                    _player.Use(new HpPotion());
                    Console.WriteLine("\nYou got +20 health.\n");
                    break;
                case 3:
                    Console.WriteLine($"\nYou escaped from a(n) {_enemy.Name}.\n");
                    _isBattleOver = true;
                    break;
            }

            if (!_enemy.IsAlive())
            {
                Console.WriteLine($"Congratulations! You killed a(n) {_enemy.Name}.");
                _player.GainExp(_enemy.Exp);
                _player.GainGold(_enemy.Gold);
                Console.WriteLine($"\n{_player.ToString()}");
                _isBattleOver = true;
            }
        }

        private void EnemyTurn()
        {
            _enemy.Attack(_player);
            Console.WriteLine($"The {_enemy.Name} damaged {_enemy.Atk}.");

            Console.WriteLine("\nPress a button to continue...");
            Console.ReadKey();

            if (!_player.IsAlive())
            {
                Console.WriteLine("You lost.");
                _isBattleOver = true;
            }
        }

        private int GetInput(int maxChoice)
        {
            int choice;

            do
            {
                Console.Write($"Write your choice (1-{maxChoice}): ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxChoice);

            return choice;

        }

        static void PressEnterToContinue()
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
