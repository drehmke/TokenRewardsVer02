using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface ILectureService
    {
        IList<Lecture> GetAllLectures();
        IList<Lecture> GetAllLecturesByPresenterId(string id);
        Lecture GetLectureById(int id);
        void SaveLecture(Lecture lectureToSave);
        void DeleteLecture(int id);
    }
}
