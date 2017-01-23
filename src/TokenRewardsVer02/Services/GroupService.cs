using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Services
{
    public class GroupService : IGroupService
    {
        IGenericRepository _repo;
        // get
        public IList<Group> GetAllGroups()
        {
            return _repo.Query<Group>().ToList();
        }
        public IList<Group> GetAllByActive(bool activeFlag)
        {
           return _repo.Query<Group>().Where(g => g.isActive == activeFlag).Include(g => g.Type).ToList();
        }

        public Group GetGroupById(int id)
        {
            return _repo.Query<Group>().Where(g => g.Id == id).Include(g => g.Type).FirstOrDefault();
        }

        // save
        public void SaveGroup(Group groupToSave)
        {
            if(groupToSave.Id == 0)
            {
                groupToSave.isActive = true;
                _repo.Add(groupToSave);
            } else
            {
                _repo.Update(groupToSave);
            }
        }

        // delete
        public void SoftDeleteGroup(int id)
        {
            Group groupToDelete = _repo.Query<Group>().Where(g => g.Id == id).FirstOrDefault();
            groupToDelete.isActive = false;
            _repo.Update(groupToDelete);
        }

        public void DeleteGroup(int id)
        {
            Group groupToDelete = _repo.Query<Group>().Where(g => g.Id == id).FirstOrDefault();
            _repo.Delete(groupToDelete);
        }

        public GroupService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}
