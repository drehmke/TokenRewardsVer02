using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Services
{
    public class RewardService : IRewardService
    {
        private IGenericRepository _repo;

        // ---- Basic CRUD ------------------------------------------------------
        public IList<Reward> GetAllRewards()
        {
            return _repo.Query<Reward>().ToList();
        }

        public Reward GetRewardById(int id)
        {
            return _repo.Query<Reward>().Where(r => r.Id == id).FirstOrDefault();
        }

        public void SaveReward(Reward rewardToSave)
        {
            if( rewardToSave.Id == 0 )
            {
                _repo.Add(rewardToSave);
            } else
            {
                _repo.Update(rewardToSave);
            }
        }

        public void DeleteReward(int id)
        {
            Reward rewardToDelete = _repo.Query<Reward>().Where(r => r.Id == id).FirstOrDefault();
            _repo.Delete(rewardToDelete);
        }
        // ---- End Basic CRUD --------------------------------------------------
        // ---- If Adding Anything Below This Line - ReExtract The Interface ----
        public RewardService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}
