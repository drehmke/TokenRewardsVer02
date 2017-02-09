using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenRewardsVer02.Models
{
    public class Recognition
    {
        public int Id { get; set; }
        public DateTime DateOfRecognition { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Log { get; set; }
    }
}
