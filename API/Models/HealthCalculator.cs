using API.database;
using API.Interfaces;

namespace API.Models
{
    public class HealthCalculator
    {
        public int TestID { get; set; }
        public string PlantType { get; set; }
        public string TimesWatered { get; set; }
        public IHealthCalculatorDataHandler DataHandler { get; set; }

        public HealthCalculator()
        {
            DataHandler = new HealthCalculatorDataHandler();
        }
    }
}