using System.Collections.Generic;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface IRewardService
    {
        void DeleteReward(int id);
        IList<Reward> GetAllRewards();
        Reward GetRewardById(int id);
        void SaveReward(Reward rewardToSave);
    }
}