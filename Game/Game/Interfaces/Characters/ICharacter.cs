using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface ICharacter
    {
        string Name { get; set; }
        int Health { get; set; }
        int Attack { get; set; }
        int Defense { get; set; }

    }
}
