using System;
using API.database;
using API.Interfaces;

namespace API.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public IAdminDataHandler DataHandler { get; set; }

        public Admin()
        {
            DataHandler = new AdminDataHandler();
        }
    }
}