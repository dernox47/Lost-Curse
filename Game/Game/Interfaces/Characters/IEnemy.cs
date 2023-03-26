using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces.Characters
{
    interface IEnemy : ICharacter
    {
        int Level { get; set; }
        int Experience { get; set; }
        int Gold { get; set; }
        void Attack(IPlayer player);
        void TakeDamage(int damage);
        bool IsAlive();
    }
}
