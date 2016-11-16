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

        public IList<UserRewards> GetRewardsByUserId(string userId)
        {   // get rewards by user
            List<UserRewards> userRewards = _repo.Query<UserRewards>().Where(ur => ur.UserId == userId).ToList();
            return userRewards;
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
