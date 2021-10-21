using System.Collections.Generic;
using System.Dynamic;
using API.Interfaces;
using API.Models;

namespace API.database
{
    public class HealthCalculatorDataHandler : IHealthCalculatorDataHandler
    {
        private Database db { get; set; }
        public HealthCalculatorDataHandler()
        {
            db = new Database();
        }
        public void Delete(HealthCalculator healthCalculator)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(HealthCalculator healthCalculator)
        {
            throw new System.NotImplementedException();
        }

        public List<HealthCalculator> Select()
        {
            List<HealthCalculator> myCalculator = new List<HealthCalculator>();

            string stm = @"SELECT * from healthcalculator";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                HealthCalculator temp = new HealthCalculator()
                {
                    TestID = item.testid,
                    PlantType = item.planttype,
                    TimesWatered = item.timeswatered
                };
                myCalculator.Add(temp);
            }
            db.Close();
            return myCalculator;
        }

        public void Update(HealthCalculator healthCalculator)
        {
            throw new System.NotImplementedException();
        }
    }
}