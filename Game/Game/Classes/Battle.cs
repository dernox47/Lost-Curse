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
        static PressKey pressKey = new PressKey();
        private Player _player { get; set; }
        private Enemy _enemy { get; set; }
        private bool _isPlayerTurn;
        private bool _isBattleOver;
        public bool _enemyDefeated { get; private set; }

        public Battle() {}

        public Battle(Player player, Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
            _isPlayerTurn = true;
            _isBattleOver = false;
            _enemyDefeated = false;
        }

        public void Begin()
        {
            Console.Clear();
            Console.WriteLine($"A(n) {_enemy.Name} appeared.\n");
            Console.WriteLine($"{_player.Name} ({_player.Hp}/{_player.MaxHp})\t{_enemy.Name} ({_enemy.Hp}/{_enemy.MaxHp})\n", Console.ForegroundColor = ConsoleColor.Red);
            Console.ResetColor();
            Console.WriteLine("Press [enter] to start the fight...");

            pressKey.Enter();

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
            Console.WriteLine("It's your turn:");
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
                Console.WriteLine($"Congratulations! You defeated a(n) {_enemy.Name}.");
                _player.GainExp(_enemy.Exp);
                _player.GainGold(_enemy.Gold);
                Rewards();
                _isBattleOver = true;
                _enemyDefeated = true;
                Console.WriteLine("Press [enter] to continue...");
                pressKey.Enter();
            }
        }

        private void EnemyTurn()
        {
            _enemy.Attack(_player);
            Console.WriteLine($"The {_enemy.Name} damaged {_enemy.Atk}.");

            Console.WriteLine("\nPress [enter] to continue...");
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 0);
            Console.Write($"{_player.Name} ({_player.Hp}/{_player.MaxHp})\t{_enemy.Name} ({_enemy.Hp}/{_enemy.MaxHp})\n", Console.ForegroundColor = ConsoleColor.Red);
            Console.ResetColor();
            pressKey.Enter();


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
                Console.Write($"Enter your choice (1-{maxChoice}): ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxChoice);

            return choice;

        }

        private void Rewards()
        {
            Console.WriteLine();
            if (_enemy.Exp != 0)
            {
                Console.WriteLine($"+{_enemy.Exp} XP");
            }
            if (_enemy.Gold != 0)
            {
                Console.WriteLine($"+{_enemy.Gold} Gold");
            }
            Console.WriteLine();
        }

    }
}
