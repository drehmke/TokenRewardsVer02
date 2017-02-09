using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Services
{
    public class StoryService : IStoryService
    {
        IGenericRepository _repo;
        ILinkService _link;

        public IEnumerable<Story> GetAllStories()
        {
            IList<Story> allStories = _repo.Query<Story>().Include(s => s.ForumLink).ToList();
            // will probably need a view model for this
            return allStories;
        }

        public Story GetStoryById(int id)
        {
            Story viewableStory = _repo.Query<Story>().Include(s => s.ForumLink).FirstOrDefault();
            // will probably need a view model for thos
            return viewableStory;
        }

        public void SaveStory(Story storyToSave)
        {
            if ( storyToSave.Id == 0 )
            {
                _repo.Add(storyToSave);
            } else
            {
                _repo.Update(storyToSave);
            }
            _link.SaveLink(storyToSave.ForumLink);
        }

        public void DeleteStory(int id)
        {
            Story storyToDelete = _repo.Query<Story>().Where(s => s.Id == id).FirstOrDefault();
            _repo.Delete(storyToDelete);
        }

        public StoryService(IGenericRepository repo, ILinkService link)
        {
            this._repo = repo;
            this._link = link;
        }
    }
}
