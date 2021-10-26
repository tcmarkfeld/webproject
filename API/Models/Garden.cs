using API.database;
using API.Interfaces;

namespace API.Models
{
    public class Garden
    {
        public int GardenID { get; set; }
        public string GardenType { get; set; }
        public string Information { get; set; }
        public IGardenDataHandler DataHandler { get; set; }

        public Garden()
        {
            DataHandler = new GardenDataHandler();
        }
    }
}