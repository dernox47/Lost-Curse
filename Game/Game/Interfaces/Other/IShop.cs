using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Items;
using Game.Classes;

namespace Game.Interfaces.Other
{
    interface IShop
    {
        string Name { get; set; }
        string Description { get; set; }
        Dictionary<IItem, int> Prices { get; set; }
        Dictionary<IItem, int> Stock { get; set; }
        void SellItem(IItem item, int quantity);
        void BuyItem(IItem item, int quantity);
    }
}
