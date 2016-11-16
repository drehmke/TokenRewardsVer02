using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenRewardsVer02.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Unlocked { get; set; }
        public string LinkTitle { get; set; }
        public string LinkUrl { get; set; }
        public int TokenValue { get; set; }
    }
}
