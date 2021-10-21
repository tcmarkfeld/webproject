using System.Collections.Generic;
using System.Dynamic;
using API.Interfaces;
using API.Models;

namespace API.database
{
    public class CorporateGardenDataHandler : ICorporateGardenDataHandler
    {
        private Database db { get; set; }
        public CorporateGardenDataHandler()
        {
            db = new Database();
        }
        public void Delete(CorporateGarden corporateGarden)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(CorporateGarden corporateGarden)
        {
            throw new System.NotImplementedException();
        }

        public List<CorporateGarden> Select()
        {
            List<CorporateGarden> myGarden = new List<CorporateGarden>();

            string stm = @"SELECT * from corporategarden";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                CorporateGarden temp = new CorporateGarden()
                {
                    GardenID = item.gardenid,
                    Information = item.information
                };
                myGarden.Add(temp);
            }
            db.Close();
            return myGarden;
        }

        public void Update(CorporateGarden corporateGarden)
        {
            throw new System.NotImplementedException();
        }
    }
}