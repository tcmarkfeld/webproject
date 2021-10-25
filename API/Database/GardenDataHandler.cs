using System.Collections.Generic;
using System.Dynamic;
using API.Interfaces;
using API.Models;

namespace API.database
{
    public class GardenDataHandler : IGardenDataHandler
    {
        private Database db { get; set; }
        public GardenDataHandler()
        {
            db = new Database();
        }
        public List<Garden> Select()
        {
            List<Garden> myGarden = new List<Garden>();

            string stm = @"SELECT * from garden";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                Garden temp = new Garden()
                {
                    GardenID = item.gardenid,
                    GardenType = item.gardenType,
                    Information = item.information
                };
                myGarden.Add(temp);
            }
            db.Close();
            return myGarden;
        }

        public List<Garden> SelectID(int id)
        {
            List<Garden> myGarden = new List<Garden>();

            string stm = @"SELECT * from garden where gardenid = '" + id + "'";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                Garden temp = new Garden()
                {
                    GardenID = item.gardenid,
                    GardenType = item.gardenType,
                    Information = item.information
                };
                myGarden.Add(temp);
            }
            db.Close();
            return myGarden;
        }

        public void Delete(Garden garden)
        {
            string stm = $@"DELETE FROM garden WHERE gardenid = {garden.GardenID}";
            db.Delete(stm);
        }

        public void Insert(Garden garden)
        {
            string stm = @"INSERT INTO garden(gardenid,gardentype,information) VALUES(@id,@type,@info)";
            db.Open();
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("@id", garden.GardenID);
            fields.Add("@type", garden.GardenType);
            fields.Add("@info", garden.Information);
            db.Insert(stm, fields);
            db.Close();
        }

        public void Update(Garden garden)
        {
            string stm = @"UPDATE garden SET gardenType = @type, information = @info WHERE gardenid = @id";
            db.Open();
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("@id", garden.GardenID);
            fields.Add("@type", garden.GardenType);
            fields.Add("@info", garden.Information);
            db.Update(stm, fields);
            db.Close();
        }
    }
}