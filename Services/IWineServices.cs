using Common.Models;
using Data.Entities;

namespace Services
{
    public interface IWineServices
    {
        int AddWine(CreateWineDTO createWineDTO);
        IEnumerable<Wine> GetWines();
        void UpdateWineStock(int id, int stock);
        IEnumerable<Wine> GetByVariety(string variety);
    }
}
