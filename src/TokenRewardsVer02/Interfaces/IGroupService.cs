using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface IGroupService
    {
        IList<Group> GetAllGroups();
        IList<Group> GetAllByActive(bool activeFlag);
        Group GetGroupById(int id);
        void SaveGroup(Group groupToSave);
        void DeleteGroup(int id);
        void SoftDeleteGroup(int id);
    }
}
