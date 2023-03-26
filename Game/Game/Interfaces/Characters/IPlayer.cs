using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces.Characters
{
    interface IPlayer : ICharacter
    {
        int Level { get; set; }
        int Experience { get; set; }
        int Gold { get; set; }
        void GainExperience(int amount);
        void GainGold(int amount);
        void LevelUp();
        void Attack(IEnemy target);
        void TakeDamage(int damage);
        bool IsAlive();

    }
}
