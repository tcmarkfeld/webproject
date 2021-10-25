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
            string stm = @"INSERT INTO admin(adminid,firstName,lastName,email,position,startdate) VALUES(@id,@fn,@ln,@email,@position,@sdate)";
            db.Open();
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("@id", admin.AdminID);
            fields.Add("@fm", admin.FirstName);
            fields.Add("@ln", admin.LastName);
            fields.Add("@email", admin.Email);
            fields.Add("@id", admin.AdminID);
            fields.Add("@position", admin.Position);
            fields.Add("@sdate", admin.StartDate);
            db.Insert(stm, fields);
            db.Close();
        }

        public void Update(Admin admin)
        {
            string stm = @"UPDATE admin SET firstName = @fn, lastName = @ln, email = @email, position = @position, startdate = @sdate WHERE adminid = @id";
            db.Open();
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("@id", admin.AdminID);
            fields.Add("@fm", admin.FirstName);
            fields.Add("@ln", admin.LastName);
            fields.Add("@email", admin.Email);
            fields.Add("@id", admin.AdminID);
            fields.Add("@position", admin.Position);
            fields.Add("@sdate", admin.StartDate);
            db.Update(stm, fields);
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
    }
}