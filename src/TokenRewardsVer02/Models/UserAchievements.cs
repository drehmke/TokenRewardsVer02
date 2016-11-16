using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenRewardsVer02.Models
{
    public class UserAchievements
    {
        public ApplicationUser User { get; set; }
        public string UserID { get; set; }

        public Achievement Achievement { get; set; }
        public int AchievementId { get; set; }
    }
}
