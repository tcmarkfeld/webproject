using System.ComponentModel.Design;
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
        public void Delete(int id)
        {
            string stm = $@"DELETE FROM healthcalculator WHERE testid = {id}";

            db.Open();
            db.Delete(stm);
            db.Close();
        }

        public void Insert(HealthCalculator healthCalculator)
        {
            var values = GetValues(healthCalculator);

            string stm = @"INSERT INTO healthcalculator(testid,planttype,waterscore,sunscore) VALUES(@id,@type,@water,@sun)";

            db.Open();
            db.Insert(stm, values);
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
                    WaterScore = item.waterscore,
                    SunScore = item.sunscore
                };
                myCalculator.Add(temp);
            }
            db.Close();
            return myCalculator;
        }

        public void Update(HealthCalculator healthCalculator)
        {
            var values = GetValues(healthCalculator);
            string stm = @"UPDATE healthcalculator SET planttype = @type, timeswatered = @times WHERE testid = @id";

            db.Open();
            db.Update(stm, values);
            db.Close();
        }

        public Dictionary<string, object> GetValues(HealthCalculator healthCalculator)
        {
            var values = new Dictionary<string, object>(){
                {"@id", healthCalculator.TestID},
                {"@type", healthCalculator.PlantType},
                {"@water", healthCalculator.WaterScore},
                {"@sun", healthCalculator.SunScore}
            };

            return values;
        }
    }
}