using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Characters;

namespace Game.Classes
{
    class Player : IPlayer
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }

        public Player(string name)
        {
            Name = name;
            Hp = 100;
            MaxHp = 100;
            Atk = 10;
            Def = 0;
            Level = 1;
            Experience = 0;
            Gold = 0;
        }

        public void Attack(IEnemy target)
        {
            target.TakeDamage(Atk);
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            if (Hp < 0)
            {
                Hp = 0;
            }
        }
        public void GainExperience(int amount)
        {
            Experience += amount;
        }

        public void GainGold(int amount)
        {
            Gold += amount;
        }

        public void LevelUp()
        {
            Level += 1;
        }

        public bool IsAlive()
        {
            return Hp > 0;
        }

        public override string ToString()
        {
            return $"{Name}\n" +
                $"HP:\t{Hp}/{MaxHp}\n" +
                $"ATK:\t{Atk}\n" +
                $"DEF:\t{Def}\n" +
                $"Szint:\t{Level}\n" +
                $"EXP:\t{Experience}\n" +
                $"Arany:\t{Gold}";
        }
    }
}
