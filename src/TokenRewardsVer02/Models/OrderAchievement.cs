using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenRewardsVer02.Models
{
    public class OrderAchievement
    {
        public int Id { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime DateFinalized { get; set; }
        public DateTime DateDelivered { get; set; }
        public string Notes { get; set; }
        public string FlagStatus { get; set; }
        public ApplicationUser Player { get; set; }
        public ApplicationUser Admin { get; set; }
        public Achievement ClaimedAchievement { get; set; }
    }
}
