﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Items;
using Game.Interfaces.Characters;
using Game.Interfaces.Other;

namespace Game.Classes.Items
{
    class HpPotion : IItem, IUsableItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public string Rarity { get; set; }
        public bool CanBeSold { get; set; }

        public HpPotion()
        {
            Name = "HP Potion";
            Description = "Use it and restore your HP.";
            Value = 5;
            Rarity = "common";
            CanBeSold = true;
        }

        public void Use(Player player)
        {
            int healingAmount = 20;
            player.Heal(healingAmount);
        }
    }
}
