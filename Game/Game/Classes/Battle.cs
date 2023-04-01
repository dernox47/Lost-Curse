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
            Console.WriteLine($"Megjelent egy {_enemy.Name}\n");

            while (!_isBattleOver)
            {
                if (_isPlayerTurn)
                {
                    PlayerTurn();
                }
                else
                {
                    EnemyTurn();
                }

                _isPlayerTurn = !_isPlayerTurn;
            }

            //while (_player.IsAlive() && _enemy.IsAlive())
            //{
            //    _player.Attack(_enemy);
            //    Console.WriteLine($"Támadtál:\n" +
            //        $"{_player.Name} ({_player.Hp}/{_player.MaxHp})\t{_enemy.Name} ({_enemy.Hp}/{_enemy.MaxHp})");
            //    if (!_enemy.IsAlive())
            //    {
            //        Console.WriteLine($"Nyertél! A(z) {_enemy.Name} meghalt.");
            //        _player.GainExp(_enemy.Exp);
            //        _player.GainGold(_enemy.Gold);
            //        Console.WriteLine($"\n{_player.ToString()}");

            //        break;
            //    }

            //    _enemy.Attack(_player);
            //    Console.WriteLine($"Támadott a(z) {_enemy.Name}:\n" +
            //        $"{_player.Name} ({_player.Hp}/{_player.MaxHp})\t{_enemy.Name} ({_enemy.Hp}/{_enemy.MaxHp})\n");
            //    if (!_player.IsAlive())
            //    {
            //        Console.WriteLine("Vesztettél.");
            //        break;
            //    }
            //}
        }

        private void PlayerTurn()
        {
            Console.WriteLine("A te köröd következik:");
            Console.WriteLine("1. Támadás");
            Console.WriteLine("2. Gyógyítás");
            Console.WriteLine("3. Feladás");

            int choice = GetInput(3);

            switch (choice)
            {
                case 1:
                    _player.Attack(_enemy);
                    Console.WriteLine($"\nSebeztél {_player.Atk}-t.\n" +
                    $"{_player.Name} ({_player.Hp}/{_player.MaxHp})\t{_enemy.Name} ({_enemy.Hp}/{_enemy.MaxHp})");
                    break;
                case 2:
                    _player.Use(new HpPotion());
                    Console.WriteLine("+20 életerőt kaptál.");
                    break;
                case 3:
                    Console.WriteLine($"Elmenekültél a(z) {_enemy.Name} elől.");
                    _isBattleOver = true;
                    break;
            }

            if (!_enemy.IsAlive())
            {
                Console.WriteLine($"Gratulálok! Legyőzted a(z) {_enemy.Name}.");
                _player.GainExp(_enemy.Exp);
                _player.GainGold(_enemy.Gold);
                Console.WriteLine($"\n{_player.ToString()}");
                _isBattleOver = true;
            }
        }

        private void EnemyTurn()
        {
            _enemy.Attack(_player);
            Console.WriteLine($"\nA(z) {_enemy.Name} {_enemy.Atk}-t sebzett.\n" +
                    $"{_player.Name} ({_player.Hp}/{_player.MaxHp})\t{_enemy.Name} ({_enemy.Hp}/{_enemy.MaxHp})\n");

            if (!_player.IsAlive())
            {
                Console.WriteLine("Vesztettél.");
                _isBattleOver = true;
            }
        }

        private int GetInput(int maxChoice)
        {
            int choice;

            do
            {
                Console.Write($"Ajd meg egy lehetőséget (1-{maxChoice}): ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxChoice);

            return choice;
        }
    }
}
