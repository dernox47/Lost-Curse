using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Items;

namespace Game.Other.Interfaces
{
    interface IInventory
    {
        List<IItem> Items { get; set; }
        void AddItem(IItem item);
        void RemoveItem(IItem item);
        bool ContainsItem(IItem item);
    }
}
