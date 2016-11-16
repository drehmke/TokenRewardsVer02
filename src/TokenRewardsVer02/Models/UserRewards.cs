using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenRewardsVer02.Models
{
    public class UserRewards
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Reward Reward { get; set; }
        public int RewardId { get; set; }
    }
}
