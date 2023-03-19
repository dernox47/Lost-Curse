using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces.Items
{
    interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }
        int Value { get; set; }
        string Rarity { get; set; }
        bool CanBeSold { get; set; }
    }
}
