using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces.Items
{
    interface IWeapon : IItem
    {
        int Attack { get; set; }
    }
}
