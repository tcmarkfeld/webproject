using System.Data.Common;
using System.Data;
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
                    AdminID = item.adminid,
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
            string stm = $@"DELETE FROM admin WHERE adminid = {admin.AdminID}";
            db.Delete(stm);
        }

        public void Insert(Admin admin)
        {
            System.Console.WriteLine("Made it to the insert");

            var values = GetValues(admin);

            string stm = @"INSERT INTO admin(adminid,firstName,lastName,email,position,startdate) VALUES(@id,@fn,@ln,@email,@position,@sdate)";

            db.Open();
            db.Insert(stm, values);
            db.Close();
        }

        public void Update(Admin admin)
        {
            System.Console.WriteLine("Made it to the update");
            var values = GetValues(admin);
            string stm = @"UPDATE admin SET firstName = @fn, lastName = @ln, email = @email, position = @position, startdate = @sdate WHERE adminid = @id";

            db.Open();
            db.Update(stm, values);
            db.Close();
        }

        public List<Admin> SelectID(int id)
        {
            List<Admin> myAdmin = new List<Admin>();

            string stm = @"SELECT * from admin where adminid = '" + id + "'";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                Admin temp = new Admin()
                {
                    AdminID = item.adminid,
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

        public Dictionary<string, object> GetValues(Admin admin)
        {
            var values = new Dictionary<string, object>(){
                {"@id", admin.AdminID},
                {"@fn", admin.FirstName},
                {"@ln", admin.LastName},
                {"@email", admin.Email},
                {"@position", admin.Position},
                {"@sdate", admin.StartDate}
            };

            return values;
        }
    }
}