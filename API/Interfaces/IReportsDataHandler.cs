using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IReportsDataHandler
    {
        public List<Reports> Select();
        public void Delete(Reports reports);
        public void Insert(Reports reports);
        public void Update(Reports reports);
    }
}