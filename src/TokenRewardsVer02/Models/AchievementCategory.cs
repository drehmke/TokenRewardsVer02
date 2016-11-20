using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenRewardsVer02.Models
{
    public class AchievementCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilterCategory { get; set; }
        public ICollection<Achievement> Achievments { get; set; }
    }
}
