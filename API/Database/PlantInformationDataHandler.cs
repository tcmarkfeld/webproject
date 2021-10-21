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
            throw new System.NotImplementedException();
        }

        public void Insert(PlantInformation plantInformation)
        {
            throw new System.NotImplementedException();
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
                };
                myPlant.Add(temp);
            }
            db.Close();
            return myPlant;
        }

        public void Update(PlantInformation plantInformation)
        {
            throw new System.NotImplementedException();
        }
    }
}