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
            string stm = $@"DELETE FROM healthcalculator WHERE testid = {healthCalculator.TestID}";
            db.Delete(stm);
        }

        public void Insert(HealthCalculator healthCalculator)
        {
            string stm = @"INSERT INTO healthcalculator(testid,planttype,timeswatered) VALUES(@id,@type,@times)";
            db.Open();
            Dictionary<string,object> fields = new Dictionary<string, object>();
            fields.Add("@id",healthCalculator.TestID);
            fields.Add("@type",healthCalculator.PlantType);
            fields.Add("@times",healthCalculator.TimesWatered);
            db.Insert(stm,fields);
            db.Close();
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
            string stm = @"UPDATE healthcalculator SET planttype = @type, timeswatered = @times WHERE testid = @id";
            db.Open();
            Dictionary<string,object> fields = new Dictionary<string, object>();
            fields.Add("@id",healthCalculator.TestID);
            fields.Add("@type",healthCalculator.PlantType);
            fields.Add("@times",healthCalculator.TimesWatered);
            db.Update(stm,fields);
            db.Close();
        }
    }
}