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
        public void Delete(PlantInformation plantInformation)
        {
            string stm = $@"DELETE FROM plantinformation WHERE plantid = {plantInformation.PlantID}";
            db.Delete(stm);
        }

        public void Insert(PlantInformation plantInformation)
        {
            string stm = @"INSERT INTO plantinformation(plantid,plantname,location,notimeswater,sunneeds,information,funfact,picture,price) VALUES(@id,@name,@location,@water,@sun,@info,@fun,@pic,@price)";
            db.Open();
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("@id", plantInformation.PlantID);
            fields.Add("@name", plantInformation.PlantName);
            fields.Add("@location", plantInformation.Location);
            fields.Add("@water", plantInformation.NumTimesWater);
            fields.Add("@sun", plantInformation.SunNeeds);
            fields.Add("@info", plantInformation.Information);
            fields.Add("@fun", plantInformation.FunFact);
            fields.Add("@pic", plantInformation.Picture);
            fields.Add("@price", plantInformation.Picture);
            db.Insert(stm, fields);
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
                    Picture = item.picture,
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
                    Picture = item.picture,
                    Price = item.price
                };
                myPlant.Add(temp);
            }
            db.Close();
            return myPlant;
        }

        public void Update(PlantInformation plantInformation)
        {
            string stm = @"UPDATE plantinformation SET plantname = @name, location = @location, notimeswater = @water, sunneeds = @sun, information = @info, funfact = @fun, picture = @pic, price = @price WHERE plantid = @id";
            db.Open();
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("@id", plantInformation.PlantID);
            fields.Add("@name", plantInformation.PlantName);
            fields.Add("@location", plantInformation.Location);
            fields.Add("@water", plantInformation.NumTimesWater);
            fields.Add("@sun", plantInformation.SunNeeds);
            fields.Add("@info", plantInformation.Information);
            fields.Add("@fun", plantInformation.FunFact);
            fields.Add("@pic", plantInformation.Picture);
            fields.Add("@price", plantInformation.Picture);
            db.Update(stm, fields);
            db.Close();
        }
    }
}