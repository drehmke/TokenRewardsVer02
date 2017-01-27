using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Services
{
    public class RankService : IRankService
    {
        IGenericRepository _repo;

        // get
        public IList<Rank> GetAllRanks()
        {
            IList<Rank> ranks = _repo.Query<Rank>().Include( r => r.BelongsTo).ToList();
            return ranks;
        }
        public IList<Rank> GetAllRanksForGroup(int gid)
        {
            IList<Rank> ranks = _repo.Query<Rank>().Where(r => r.BelongsTo.Id == gid).Include( r => r.BelongsTo).ToList();
            return ranks;
        }
        public Rank GetRankById(int id)
        {
            Rank rankToView = _repo.Query<Rank>().Where(r => r.Id == id).Include( r => r.BelongsTo).FirstOrDefault();
            return rankToView;
        }

        // save
        public void SaveRank(Rank rankToSave)
        {
            if( rankToSave.Id == 0)
            {
                Group groupToUse = _repo.Query<Group>().Where(g => g.Id == rankToSave.BelongsTo.Id).FirstOrDefault();
                rankToSave.BelongsTo = groupToUse;
                rankToSave.isActive = true;
                _repo.Add(rankToSave);
            } else
            {
                _repo.Update(rankToSave);
            }
        }

        // delete
        public void SoftDelete(int id)
        {
            Rank rankToDelete = _repo.Query<Rank>().Where(r => r.Id == id).FirstOrDefault();
            rankToDelete.isActive = false;
            _repo.Update(rankToDelete);
        }

        public void Delete(int id)
        {
            Rank rankToDelete = _repo.Query<Rank>().Where(r => r.Id == id).FirstOrDefault();
            _repo.Delete(rankToDelete);
        }

        public RankService( IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}
