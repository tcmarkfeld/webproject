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
                    Password = item.password,
                    Position = item.position,
                    StartDate = item.startdate,
                };
                myAdmin.Add(temp);
            }
            db.Close();
            return myAdmin;
        }

        public void Delete(int id)
        {
            string stm = $@"DELETE FROM admin WHERE adminid = {id}";

            db.Open();
            db.Delete(stm);
            db.Close();
        }

        public void Insert(Admin admin)
        {
            System.Console.WriteLine("Made it to the insert");

            var values = GetValues(admin);

            string stm = @"INSERT INTO admin(adminid,firstName,lastName,email,password,position,startdate) VALUES(@id,@fn,@ln,@email,@pass,@position,@sdate)";

            db.Open();
            db.Insert(stm, values);
            db.Close();
        }

        public void Update(Admin admin)
        {
            System.Console.WriteLine("Made it to the update");

            var values = GetValues(admin);

            string stm = @"UPDATE admin SET firstName = @fn, lastName = @ln, email = @email, password = @pass, position = @position, startdate = @sdate WHERE adminid = @id";

            db.Open();
            db.Update(stm, values);
            db.Close();
        }

        public List<Admin> SelectEmail(string email)
        {
            List<Admin> myAdmin = new List<Admin>();

            string stm = @"SELECT * from admin where email = '" + email + "'";
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
                    Password = item.password,
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
                {"@pass", admin.Password},
                {"@position", admin.Position},
                {"@sdate", admin.StartDate}
            };

            return values;
        }
    }
}