using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenRewardsVer02.Models
{
    public class Rank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Group BelongsTo { get; set; }
        public bool isActive { get; set; }
        public int Level { get; set; }
    }
}
