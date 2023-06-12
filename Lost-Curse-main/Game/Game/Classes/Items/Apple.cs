
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Items;
using Game.Interfaces.Characters;
using Game.Interfaces.Other;

namespace Game.Classes.Items
{
    class Apple : IItem, IUsableItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public string Rarity { get; set; }
        public bool CanBeSold { get; set; }

        public Apple()
        {
            Name = "Apple";
            Description = "Eat a delicious apple and restore 5 HP.";
            Value = 2;
            Rarity = "common";
            CanBeSold = true;
        }

        public void Use(Player player) {
            int healingAmount = 5;
            player.Heal(healingAmount);
        }
    }
}
