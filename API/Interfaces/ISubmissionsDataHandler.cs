using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface ISubmissionsDataHandler
    {
        public List<Submissions> Select();
        public void Delete(int id);
        public void Insert(Submissions submissions);
        public void Update(Submissions submissions);
    }
}