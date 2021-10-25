using System.Reflection.Metadata;
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
        public byte[] Picture { get; set; }
        public double Price { get; set; }
    }
}