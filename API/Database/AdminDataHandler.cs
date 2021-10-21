using System.Collections.Generic;
using System.Dynamic;
using API.Interfaces;
using API.Models;

namespace API.database
{
    public class AdminDataHandler : IAdminDataHandler
    {
        private Database db { get; set; }
        public AdminDataHandler()
        {
            db = new Database();
        }
        public List<Admin> Select()
        {
            List<Admin> myAdmin = new List<Admin>();

            string stm = @"SELECT * from admin";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                Admin temp = new Admin()
                {
                    ID = item.adminid,
                    FirstName = item.firstName,
                    LastName = item.lastName,
                    Email = item.email,
                    Position = item.position,
                    StartDate = item.startdate,
                };
                myAdmin.Add(temp);
            }
            db.Close();
            return myAdmin;
        }

        public void Delete(Admin admin)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Admin admin)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Admin admin)
        {
            throw new System.NotImplementedException();
        }
    }
}