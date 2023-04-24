using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Characters;

namespace Game.Classes
{
    class Enemy : IEnemy
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Gold { get; set; }

        public Enemy(string name, int hp, int maxhp, int atk, int def, int level, int exp, int gold)
        {
            Name = name;
            Hp = hp;
            MaxHp = maxhp;
            Atk = atk;
            Def = def;
            Level = level;
            Exp = exp;
            Gold = gold;
        }

        public void Attack(IPlayer player)
        {
            player.TakeDamage(Atk);
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            if (Hp < 0)
            {
                Hp = 0;
            }
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
                $"EXP:\t{Exp}\n" +
                $"Arany:\t{Gold}";
        }
    }
}
