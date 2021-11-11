using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IAdminDataHandler
    {
        public List<Admin> Select();
        public void Delete(int id);
        public void Insert(Admin admin);
        public void Update(Admin admin);
        public List<Admin> SelectEmail(string email);
    }
}