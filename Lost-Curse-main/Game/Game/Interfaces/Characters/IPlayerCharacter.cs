using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces.Characters
{
    interface IPlayerCharacter : ICharacter
    {
        int Level { get; set; }
        int Experience { get; set; }
        int Gold { get; set; }
        void GainExperience(int amount);
        void GainGold(int amount);
        void LevelUp();
    }
}
