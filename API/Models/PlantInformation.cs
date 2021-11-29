using API.database;
using API.Interfaces;

namespace API.Models
{
    public class PlantInformation
    {
        public int PlantID { get; set; }
        public string PlantName { get; set; }
        public string Location { get; set; }
        public string NumTimesWater { get; set; }
        public string SunNeeds { get; set; }
        public string Information { get; set; }
        public string FunFact { get; set; }
        public string Price { get; set; }
        public IPlantInformationDataHandler DataHandler { get; set; }

        public PlantInformation()
        {
            DataHandler = new PlantInformationDataHandler();
        }
    }
}