using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;
using TokenRewardsVer02.ViewModels.Achievement;

namespace TokenRewardsVer02.Services
{
    public class AchievementService : IAchievementService
    {
        private IGenericRepository _repo;
        private IAchievementCategoryService _acService;
        

        // ---- Basic CRUD -------------------------------------------------------
        public IList<AchievementForView> GetAllAchievements()
        {
            IList<Achievement> allAchievements = _repo.Query<Achievement>().ToList();
            IList<AchievementCategory> allCategories = _repo.Query<AchievementCategory>().ToList();
            IList<AchievementForView> filterableAchievements = new List<AchievementForView>();
            foreach(Achievement achievements in allAchievements )
            {
                if( achievements != null )
                {
                    AchievementForView tmp = new AchievementForView
                    {
                        Id = achievements.Id,
                        Title = achievements.Title,
                        Description = achievements.Description,
                        Unlocked = achievements.Unlocked,
                        LinkTitle = achievements.LinkTitle,
                        LinkUrl = achievements.LinkUrl,
                        TokenValue = achievements.TokenValue,
                        FilterCategory = achievements.AchievementCategory.FilterCategory
                    };
                    filterableAchievements.Add(tmp);
                }
            }
            return filterableAchievements;
            //return _repo.Query<Achievement>().ToList();
        }

        public AchievementForView GetByAchievementId(int id)
        {
            //return _repo.Query<Achievement>().Where(a => a.Id == id).FirstOrDefault();
            Achievement achievementToEdit = _repo.Query<Achievement>().Where(a => a.Id == id).FirstOrDefault();
            IList<AchievementCategory> allCategories = _repo.Query<AchievementCategory>().ToList();
            AchievementForView achievementToReturn = new AchievementForView
            {
                Id = achievementToEdit.Id,
                Title = achievementToEdit.Title,
                Description = achievementToEdit.Description,
                Unlocked = achievementToEdit.Unlocked,
                LinkTitle = achievementToEdit.LinkTitle,
                LinkUrl = achievementToEdit.LinkUrl,
                TokenValue = achievementToEdit.TokenValue,
                CategoryId = achievementToEdit.AchievementCategory.Id
            };
            return achievementToReturn;
        }

        public void SaveAchievement(AchievementForView achievementViewToSave)
        {
            AchievementCategory achievementCategory = _acService.GetByAchievementCategoryId(achievementViewToSave.CategoryId);
            // convert the achievementViewToSave to achievementToSave
            Achievement achievementToSave = new Achievement
            {
                Title = achievementViewToSave.Title,
                Description = achievementViewToSave.Description,
                Unlocked = achievementViewToSave.Unlocked,
                LinkTitle = achievementViewToSave.LinkTitle,
                LinkUrl = achievementViewToSave.LinkUrl,
                TokenValue = achievementViewToSave.TokenValue,
            };
            if ( achievementViewToSave.Id == 0 )
            {
                _repo.Add(achievementToSave);
                // we need to add it to the category ...
                // TODO: Edit form is not pulling all the categories. Not required for MVP 
                //achievementCategory.Achievments = new List<Achievement>();
                //achievementCategory.Achievments.Add(achievementToSave);
                //_repo.SaveChanges();
            }
            else
            {
                _repo.Update(achievementToSave);
                // we need to update to the category ...
            }
            achievementCategory.Achievments = new List<Achievement>();
            achievementCategory.Achievments.Add(achievementToSave);
            _repo.SaveChanges();
        }

        public void DeleteAchievement(int id)
        {
            Achievement achievementToDelete = _repo.Query<Achievement>().Where(a => a.Id == id).FirstOrDefault();
            _repo.Delete(achievementToDelete);
        }
        // ---- End Basic CRUD ---------------------------------------------------
        // ---- If adding anything below this line - re-extract the Interface ----
        // add to parameters: IPrincipal user
        // inside method: user.FindByNameAsync(user.Identity.Name)

        public AchievementService(IGenericRepository repo, IAchievementCategoryService acService)
        {
            this._repo = repo;
            this._acService = acService;
        }
    }
}
