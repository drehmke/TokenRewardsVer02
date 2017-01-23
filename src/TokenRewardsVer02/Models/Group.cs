using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenRewardsVer02.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public GroupType Type { get; set; }
    }
}
