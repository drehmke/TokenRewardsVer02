using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenRewardsVer02.ViewModels.Orders
{
    public class OrderAchievementPlayerView
    {
        public int Id { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime DateFinalized { get; set; }
        public DateTime DateDelivered { get; set; }
        public string FlagStatus { get; set; }

        public string PlayerId { get; set; }

        public int AchievementId { get; set; }
        public string AchievementTitle { get; set; }
        public string AchievementDescription { get; set; }
    }
}
