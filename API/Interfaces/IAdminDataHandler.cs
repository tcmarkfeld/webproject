using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IAdminDataHandler
    {
        public List<Admin> Select();
        public void Delete(Admin admin);
        public void Insert(Admin admin);
        public void Update(Admin admin);
    }
}