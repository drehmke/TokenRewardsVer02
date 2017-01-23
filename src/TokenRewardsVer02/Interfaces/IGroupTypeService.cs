using System.Collections.Generic;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface IGroupTypeService
    {
        void DeleteGroupType(int id);
        IList<GroupType> GetAllGroupTypes();
        void SaveGroupType(GroupType typeToSave);
    }
}