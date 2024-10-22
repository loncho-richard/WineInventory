using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IWineRepository
    {
        IEnumerable<Wine> GetWines();
        int AddWine(Wine wine);
        void UpdateWineStock(int id, int stock);
        IEnumerable<Wine> GetByVariety();
    }
}
