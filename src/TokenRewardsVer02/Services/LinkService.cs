using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Services
{
    public class LinkService : ILinkService
    {
        IGenericRepository _repo;

        public IList<Link> GetAllLinks()
        {
            IList<Link> allLinks = _repo.Query<Link>().ToList();
            return allLinks;
        }

        public Link GetLinkById(int id)
        {
            Link returnableLink = _repo.Query<Link>().Where(l => l.Id == id).FirstOrDefault();
            return returnableLink;
        }

        public void SaveLink(Link linkToSave)
        {
            if(linkToSave.Id == 0 )
            {
                linkToSave.DateAdded = DateTime.Now;
                _repo.Add(linkToSave);
            } else
            {
                _repo.Update(linkToSave);
            }
        }

        public void Delete(int id)
        {
            Link linkToDelete = _repo.Query<Link>().Where(l => l.Id == id).FirstOrDefault();
            _repo.Delete(linkToDelete);
        }

        public LinkService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}
