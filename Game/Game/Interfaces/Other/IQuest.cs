using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Items;
using Game.Interfaces.Characters;

namespace Game.Interfaces.Other
{
    interface IQuest
    {
        string Name { get; set; }
        string Description { get; set; }
        int ExperienceReward { get; set; }
        int GoldReward { get; set; }
        List<IItem> ItemRewards { get; set; }
        bool IsComplete { get; set; }
        void CheckComplition();
    }
}
