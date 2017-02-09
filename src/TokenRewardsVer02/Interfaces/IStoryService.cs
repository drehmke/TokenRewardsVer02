using System.Collections.Generic;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface IStoryService
    {
        void DeleteStory(int id);
        IEnumerable<Story> GetAllStories();
        Story GetStoryById(int id);
        void SaveStory(Story storyToSave);
    }
}