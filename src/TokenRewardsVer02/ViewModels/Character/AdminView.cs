using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenRewardsVer02.ViewModels.Character
{
    public class AdminView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int WufooFormId { get; set; }
        public bool Active { get; set; }
    }
}
