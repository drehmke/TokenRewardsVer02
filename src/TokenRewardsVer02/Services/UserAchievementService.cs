using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Services
{
    public class UserAchievementService : IUserAchievementService
    {
        private IGenericRepository _repo;
        private IAchievementService _aservice;
        private readonly UserManager<ApplicationUser> _userManager;

        // ---- Basic CRUD ----------------------------------------------------
        public IList<UserAchievements> GetAllUserAchievements()
        {   // this gets everything
            return _repo.Query<UserAchievements>().ToList();
        }

        public IList<UserAchievements> GetAchievementsByUserName(string userId)
        { // get achievements by user
            List<UserAchievements> usersAchievements = _repo.Query<UserAchievements>().Where(ua => ua.UserID == userId).ToList();


            return usersAchievements;
        }

        
        public void ClaimAchievement(string userid, int aid)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.UserName == userid).FirstOrDefault();
            var achievment = _repo.Query<Achievement>().Where(a => a.Id == aid).FirstOrDefault();

            var join = new UserAchievements
            {
                UserID = user.Id,
                AchievementId = aid
            };

            _repo.Add(join);
            // update the user's token value
            user.TokenTotal = user.TokenTotal + achievment.TokenValue;

            _repo.SaveChanges();
            /*
                var loggedInUser = await _userManager.FindByNameAsync(user.Identity.Name);
                if (userAchievement.Achievement == null && userAchievement.AchievementId != 0)
                {  // we have data from the client, but not everything
                    userAchievement.Achievement = _aservice.GetByAchievementId(userAchievement.AchievementId);
                    //userAchievement.User = await _userManager.FindByIdAsync(loggedInUser.Id);

                }
                _repo.Add(userAchievement);
                _repo.SaveChanges();
                */
        }

        //public void DeleteAchievementForUser(UserAchievements achievementToDelete)
        // --------------------------------------------------------------------


        public UserAchievementService( IGenericRepository repo, IAchievementService aservice)
        {
            this._repo = repo;
            this._aservice = aservice;
            //this._userManager = userManager;
        }
    }
}
