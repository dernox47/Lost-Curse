using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces.Items
{
    interface IArmor : IItem
    {
        int Defense { get; set }
    }
}
