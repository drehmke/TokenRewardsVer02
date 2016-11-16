using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Services
{
    public class UserRewardService : IUserRewardService
    {
        private IGenericRepository _repo;
        private IRewardService _rservice;

        public IList<UserRewards> GetAllUserRewards()
        {
            return _repo.Query<UserRewards>().ToList();
        }

        public IList<Reward> GetRewardsByUserName(string userName)
        {   // get rewards by userId when we pass the userName - so we need to find the user's ID based on the userName
            ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.UserName == userName).FirstOrDefault();
            IList<UserRewards> allRecords = _repo.Query<UserRewards>().ToList();
            IList<Reward> rewardsList = new List<Reward>();
            foreach( UserRewards r in allRecords)
            {
                if(user.Id == r.UserId)
                {
                    rewardsList.Add(_rservice.GetRewardById(r.RewardId));
                }
            }
            return rewardsList;
        }

        public void ClaimReward(string userId, int rewardId)
        {
            ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.UserName == userId).FirstOrDefault();
            Reward reward = _repo.Query<Reward>().Where(r => r.Id == rewardId).FirstOrDefault();

            UserRewards claimedReward = new UserRewards
            {
                Reward = reward,
                RewardId = reward.Id,
                User = user,
                UserId = user.Id
            };
            _repo.Add(claimedReward);
            // now subtract the total from the user's TokenTotal
            user.TokenTotal = user.TokenTotal - reward.Price;
            // save the updated TokenTotal as well as another chance to save the relation
            _repo.SaveChanges();
        }

        public UserRewardService( IGenericRepository repo, IRewardService rservice)
        {
            this._repo = repo;
            this._rservice = rservice;
        }
    }
}
