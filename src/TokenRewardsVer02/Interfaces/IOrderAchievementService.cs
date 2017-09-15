using System.Collections.Generic;
using TokenRewardsVer02.ViewModels.Orders;

namespace TokenRewardsVer02.Interfaces
{
    public interface IOrderAchievementService
    {
        IList<OrderAchievementPlayerView> GetAllOrderedAchievementsByUserName(string userName);
        void OrderNewAchievement(string uid, int aid);
    }
}