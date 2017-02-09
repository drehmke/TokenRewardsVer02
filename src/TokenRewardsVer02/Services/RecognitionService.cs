using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Services
{
    public class RecognitionService : IRecognitionService
    {
        IGenericRepository _repo;

        public IList<Recognition> GetAllRecognitions()
        {
            IList<Recognition> allRecognitions = _repo.Query<Recognition>().ToList();
            // will probably need a view model for this
            return allRecognitions;
        }

        public Recognition GetRecognitionById(int id)
        {
            Recognition viewableRecognition = _repo.Query<Recognition>().Where(r => r.Id == id).FirstOrDefault();
            return viewableRecognition;
        }

        public void SaveRecognition(Recognition recognitionToSave)
        {
            if(recognitionToSave.Id == 0)
            {
                _repo.Add(recognitionToSave);
            } else
            {
                _repo.Update(recognitionToSave);
            }
        }

        public void DeleteRecognition(int id)
        {
            Recognition recognitionToDelete = _repo.Query<Recognition>().Where(r => r.Id == id).FirstOrDefault();
            _repo.Delete(recognitionToDelete);
        }

        public RecognitionService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}
