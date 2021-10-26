using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IGardenDataHandler
    {
        public List<Garden> Select();
        public List<Garden> SelectID(int id);
        public void Delete(int id);
        public void Insert(Garden garden);
        public void Update(Garden garden);
    }
}