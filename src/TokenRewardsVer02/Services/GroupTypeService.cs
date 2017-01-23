using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Services
{
    public class GroupTypeService : IGroupTypeService
    {
        private IGenericRepository _repo;
        // add / edit
        public void SaveGroupType(GroupType typeToSave)
        {
            if( typeToSave.Id == 0 )
            {
                _repo.Add(typeToSave);
            } else
            {
                _repo.Update(typeToSave);
            }
        }

        // view
        public IList<GroupType> GetAllGroupTypes()
        {
            return _repo.Query<GroupType>().ToList();
        }

        // delete
        public void DeleteGroupType(int id)
        {
            GroupType typeToDelete = _repo.Query<GroupType>().Where(g => g.Id == id).FirstOrDefault();
            _repo.Delete(typeToDelete);
        }

        // constructor
        public GroupTypeService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}
