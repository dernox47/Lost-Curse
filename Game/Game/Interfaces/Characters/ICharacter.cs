using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces.Characters
{
    interface ICharacter
    {
        string Name { get; set; }
        int Hp { get; set; }
        int MaxHp { get; set; }
        int Atk { get; set; }
        int Def { get; set; }

    }
}
