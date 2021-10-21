using System;

namespace API.Models
{
    public class Admin
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
    }
}