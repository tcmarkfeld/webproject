using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IGardenDataHandler
    {
        public List<Garden> Select();
        public void Delete(Garden garden);
        public void Insert(Garden garden);
        public void Update(Garden garden);
    }
}