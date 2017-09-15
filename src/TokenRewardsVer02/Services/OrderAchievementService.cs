using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;
using TokenRewardsVer02.ViewModels.Orders;

namespace TokenRewardsVer02.Services
{
    public class OrderAchievementService : IOrderAchievementService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;

        // Convert to Player View
        private OrderAchievementPlayerView ConvertToPlayerView(OrderAchievement orderToConvert)
        {
            OrderAchievementPlayerView convertedOrder = new OrderAchievementPlayerView();
            convertedOrder.Id = orderToConvert.Id;
            convertedOrder.DateOrdered = orderToConvert.DateOrdered;
            convertedOrder.DateFinalized = orderToConvert.DateFinalized;
            convertedOrder.DateDelivered = orderToConvert.DateDelivered;
            convertedOrder.FlagStatus = orderToConvert.FlagStatus;
            convertedOrder.PlayerId = orderToConvert.Player.Id;
            convertedOrder.AchievementId = orderToConvert.ClaimedAchievement.Id;
            convertedOrder.AchievementDescription = orderToConvert.ClaimedAchievement.Description;

            return convertedOrder;
        }

        private static void NewMethod(OrderAchievement orderToConvert, OrderAchievementPlayerView convertedOrder)
        {
            convertedOrder.AchievementTitle = orderToConvert.ClaimedAchievement.Title;
        }

        // Convert to Admin View

        // Player Facing Functions
        public IList<OrderAchievementPlayerView> GetAllOrderedAchievementsByUserName(string userName)
        {
            ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.UserName == userName).FirstOrDefault();
            IList<OrderAchievement> allOrderedAchievements = _repo.Query<OrderAchievement>().Include(o => o.Player).Where(o => o.Player.Id == user.Id).ToList();
            IList<OrderAchievementPlayerView> listableAchievements = new List<OrderAchievementPlayerView>();
            foreach (OrderAchievement orderedAchievement in allOrderedAchievements)
            {
                listableAchievements.Add(this.ConvertToPlayerView(orderedAchievement));
            }

            return listableAchievements;
        }

        public void OrderNewAchievement(string uid, int aid)
        {
            // grab the player so we can associate it
            ApplicationUser player = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
            // grab the achievement so we can associate it
            Achievement achievement = _repo.Query<Achievement>().Where(a => a.Id == aid).FirstOrDefault();

            OrderAchievement newAchievementOrder = new OrderAchievement();
            newAchievementOrder.DateOrdered = DateTime.Now;
            newAchievementOrder.FlagStatus = "p";
            newAchievementOrder.Player = player;
            newAchievementOrder.ClaimedAchievement = achievement;
            _repo.Add(newAchievementOrder);
        }



        public OrderAchievementService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}
