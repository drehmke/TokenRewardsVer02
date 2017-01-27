using System.Collections.Generic;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface IRankService
    {
        void Delete(int id);
        IList<Rank> GetAllRanks();
        IList<Rank> GetAllRanksForGroup(int gid);
        Rank GetRankById(int id);
        void SaveRank(Rank rankToSave);
        void SoftDelete(int id);
    }
}