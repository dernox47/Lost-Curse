
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Items;
using Game.Interfaces.Characters;

namespace Game
{
    class Apple : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public string Rarity { get; set; }
        public bool CanBeSold { get; set; }

        public Apple()
        {
            Name = "Alma";
            Description = "Egyen egy finom almát és töltsön vissza 5 életerőt!";
            Value = 2;
            Rarity = "gyakori";
            CanBeSold = true;
        }

        public void Use(IPlayer player) {

            player.Hp += 5;
            if (player.Hp >= player.MaxHp)
            {
                player.Hp = player.MaxHp;
            }
        }
    }
}
