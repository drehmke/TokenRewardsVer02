using System.Collections.Generic;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface IRecognitionService
    {
        void DeleteRecognition(int id);
        IList<Recognition> GetAllRecognitions();
        Recognition GetRecognitionById(int id);
        void SaveRecognition(Recognition recognitionToSave);
    }
}