using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenRewardsVer02.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WufooId { get; set; }
        public Link ForumLink { get; set; }
    }
}
