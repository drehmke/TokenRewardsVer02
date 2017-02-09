using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Services
{
    public class LectureService: ILectureService
    {
        IGenericRepository _repo;

        public IList<Lecture> GetAllLectures()
        {
            IList<Lecture> allLectures = _repo.Query<Lecture>().Include(l => l.Presenter).ToList();
            // will need a view model for this
            return allLectures;
        }

        public IList<Lecture> GetAllLecturesByPresenterId(string id)
        {
            IList<Lecture> allLectures = _repo.Query<Lecture>().Include(l => l.Presenter).Where(l => l.Presenter.Id == id).ToList();
            // will need a view model for this
            return allLectures;
        }

        public Lecture GetLectureById(int id)
        {
            Lecture lectureToView = _repo.Query<Lecture>().Where(l => l.Id == id).Include(l => l.Presenter).FirstOrDefault();
            // will need a view model for this
            return lectureToView;
        }

        public void SaveLecture(Lecture lectureToSave)
        {
            if( lectureToSave.Id == 0 )
            {
                ApplicationUser presenter = _repo.Query<ApplicationUser>().Where(u => u.Id == lectureToSave.Presenter.Id).FirstOrDefault();
                lectureToSave.Presenter = presenter;
                _repo.Add(lectureToSave);
            } else
            {
                // just in case the presenterId changes
                ApplicationUser presenter = _repo.Query<ApplicationUser>().Where(u => u.Id == lectureToSave.Presenter.Id).FirstOrDefault();
                lectureToSave.Presenter = presenter;
                _repo.Update(lectureToSave);
            }
        }

        public void DeleteLecture(int id)
        {
            Lecture lectureToDelete = _repo.Query<Lecture>().Where(l => l.Id == id).FirstOrDefault();
            _repo.Delete(lectureToDelete);
        }

        public LectureService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}
