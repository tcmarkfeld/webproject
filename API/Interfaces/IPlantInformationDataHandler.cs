using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IPlantInformationDataHandler
    {
        public List<PlantInformation> Select();
        public List<PlantInformation> SelectHighest();
        public List<PlantInformation> SelectID(int id);
        public void Delete(int id);
        public void Insert(PlantInformation plantInformation);
        public void Update(PlantInformation plantInformation);
    }
}