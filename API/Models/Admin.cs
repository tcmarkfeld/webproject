using System;

namespace API.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; } // going to run into a problem here need to either find date or change it in database
    }
}