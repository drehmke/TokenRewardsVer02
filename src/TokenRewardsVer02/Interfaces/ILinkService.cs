using System.Collections.Generic;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface ILinkService
    {
        void Delete(int id);
        IList<Link> GetAllLinks();
        Link GetLinkById(int id);
        void SaveLink(Link linkToSave);
    }
}