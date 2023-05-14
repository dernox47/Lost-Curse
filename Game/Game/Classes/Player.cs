using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Characters;
using Game.Interfaces.Items;
using Game.Interfaces.Other;

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
        public int Exp { get; set; }
        public int MaxExp { get; set; }
        public int Gold { get; set; }
        public Inventory inventory = new Inventory();

        public Player(string name = "Player")
        {
            Name = name;
            Hp = 100;
            MaxHp = 100;
            Atk = 10;
            Def = 0;
            Level = 1;
            Exp = 0;
            MaxExp = 100;
            Gold = 100;
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
        public void GainExp(int amount)
        {
            Exp += amount;

            while (Exp >= MaxExp)
            {
                Level++;
                MaxExp += 100;
                MaxHp += 10;
                Atk += 2;
                Hp = MaxHp;
                Console.WriteLine($"You leveled up! [Level {Level}]");
            }
        }

        public void GainGold(int amount)
        {
            Gold += amount;
        }

        public void LevelUp() // Lehet nem fog kelleni, de benthagyom. (SzA)
        {
            Level += 1;
        }

        public bool IsAlive()
        {
            return Hp > 0;
        }

        public void Heal(int amount)
        {
            this.Hp = Math.Min(this.Hp + amount, this.MaxHp);
        }

        public void Use(IUsableItem item)
        {
            item.Use(this);
        }

        public override string ToString()
        {
            return $"{Name}\n" +
                $"HP:\t{Hp}/{MaxHp}\n" +
                $"ATK:\t{Atk}\n" +
                $"DEF:\t{Def}\n" +
                $"Level:\t{Level}\n" +
                $"EXP:\t{Exp}/{MaxExp}\n" +
                $"Gold:\t{Gold}";
        }
    }
}
