using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IHealthCalculatorDataHandler
    {
        public List<HealthCalculator> Select();
        public void Delete(int id);
        public void Insert(HealthCalculator healthCalculator);
        public void Update(HealthCalculator healthCalculator);
    }
}