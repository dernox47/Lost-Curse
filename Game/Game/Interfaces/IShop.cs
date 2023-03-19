using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Items;

namespace Game.Interfaces
{
    interface IShop
    {
        string Name { get; set; }
        string Description { get; set; }
        List<IItem> Items { get; set; }
        void SellItem(IItem item);
        void BuyItem(IItem item);
    }
}
