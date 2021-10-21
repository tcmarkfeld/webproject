using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface ICorporateGardenDataHandler
    {
        public List<CorporateGarden> Select();
        public void Delete(CorporateGarden corporateGarden);
        public void Insert(CorporateGarden corporateGarden);
        public void Update(CorporateGarden corporateGarden);
    }
}