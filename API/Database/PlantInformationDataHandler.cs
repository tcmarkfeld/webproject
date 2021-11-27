using System.Collections.Generic;
using System.Dynamic;
using API.Interfaces;
using API.Models;

namespace API.database
{
    public class PlantInformationDataHandler : IPlantInformationDataHandler
    {
        private Database db { get; set; }
        public PlantInformationDataHandler()
        {
            db = new Database();
        }
        public void Delete(int id)
        {
            string stm = $@"DELETE FROM plantinformation WHERE plantid = {id}";

            db.Open();
            db.Delete(stm);
            db.Close();
        }

        public void Insert(PlantInformation plantInformation)
        {
            var values = GetValues(plantInformation);

            string stm = @"INSERT INTO plantinformation(plantname,location,notimeswater,sunneeds,information,funfact,price) VALUES(@name,@location,@water,@sun,@info,@fun,@price)";

            db.Open();
            db.Insert(stm, values);
            db.Close();
        }

        public List<PlantInformation> Select()
        {
            List<PlantInformation> myPlant = new List<PlantInformation>();

            string stm = @"SELECT * from plantinformation";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                PlantInformation temp = new PlantInformation()
                {
                    PlantID = item.plantid,
                    PlantName = item.plantname,
                    Location = item.location,
                    NumTimesWater = item.notimeswater,
                    SunNeeds = item.sunneeds,
                    Information = item.information,
                    FunFact = item.funfact,
                    Price = item.price
                };
                myPlant.Add(temp);
            }
            db.Close();
            return myPlant;
        }

        public List<PlantInformation> SelectID(int id)
        {
            List<PlantInformation> myPlant = new List<PlantInformation>();

            string stm = @"SELECT * from plantinformation where plantid = '" + id + "'";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                PlantInformation temp = new PlantInformation()
                {
                    PlantID = item.plantid,
                    PlantName = item.plantname,
                    Location = item.location,
                    NumTimesWater = item.notimeswater,
                    SunNeeds = item.sunneeds,
                    Information = item.information,
                    FunFact = item.funfact,
                    Price = item.price
                };
                myPlant.Add(temp);
            }
            db.Close();
            return myPlant;
        }

        public void Update(PlantInformation plantInformation)
        {
            var values = GetValues(plantInformation);
            string stm = @"UPDATE plantinformation SET plantname = @name, location = @location, notimeswater = @water, sunneeds = @sun, information = @info, funfact = @fun, price = @price WHERE plantid = @id";

            db.Open();
            db.Update(stm, values);
            db.Close();
        }

        public Dictionary<string, object> GetValues(PlantInformation plantInformation)
        {
            var values = new Dictionary<string, object>(){
                {"@id", plantInformation.PlantID},
                {"@name", plantInformation.PlantName},
                {"@location", plantInformation.Location},
                {"@water", plantInformation.NumTimesWater},
                {"@sun", plantInformation.SunNeeds},
                {"@info", plantInformation.Information},
                {"@fun", plantInformation.FunFact},
                {"@price", plantInformation.Price}
            };

            return values;
        }
    }
}