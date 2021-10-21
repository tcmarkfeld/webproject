using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IOutdoorGardenDataHandler
    {
        public List<OutdoorGarden> Select();
        public void Delete(OutdoorGarden outdoorGarden);
        public void Insert(OutdoorGarden outdoorGarden);
        public void Update(OutdoorGarden outdoorGarden);
    }
}