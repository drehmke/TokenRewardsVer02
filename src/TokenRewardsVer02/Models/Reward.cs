using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenRewardsVer02.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; } // in points/tokens
        public string Mass { get; set; }
        public string HookText { get; set; }
        public string Description { get; set; }
        public string Limitations { get; set; }
        public string Restrictions { get; set; }
        public string UseSamples { get; set; }
        public string History { get; set; }
        public bool IsPermanent { get; set; }
        public bool isPhysical { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; }
    }
}
