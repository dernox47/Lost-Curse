using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces.Characters
{
    interface IAttackable
    {
        void Attack(IAttackable target);
        void TakeDamage(int damage);
        bool IsAlive();
    }
}
