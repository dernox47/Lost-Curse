using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Characters;
using Game.Classes;

namespace Game.Interfaces.Other
{
    interface IUsableItem
    {
        void Use(Player player);
    }
}
