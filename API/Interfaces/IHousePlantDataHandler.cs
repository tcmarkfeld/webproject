using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IHousePlantDataHandler
    {
        public List<HousePlant> Select();
        public void Delete(HousePlant housePlant);
        public void Insert(HousePlant housePlant);
        public void Update(HousePlant housePlant);
    }
}