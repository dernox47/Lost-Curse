using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Items;
using Game.Interfaces.Characters;

namespace Game.Classes
{
    class Bread
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public string Rarity { get; set; }
        public bool CanBeSold { get; set; }

        public Bread()
        {
            Name = "Kenyér";
            Description = "Egyen egy finom kenyeret és töltsön vissza 8 életerőt!";
            Value = 3;
            Rarity = "gyakori";
            CanBeSold = true;
        }

        public void Use(IPlayer player)
        {

            player.Hp += 8;
            if (player.Hp >= player.MaxHp)
            {
                player.Hp = player.MaxHp;
            }


        }
    }
}
