using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class WineRepository : IWineRepository
    {
        private readonly WineInventoryContext _context;
        public WineRepository(WineInventoryContext wineInventoryContext)
        {
            _context = wineInventoryContext;
        }

        public IEnumerable<Wine> GetWines()
        {
            return _context.Wines.ToList();
        }

        public IEnumerable<Wine> GetWineInStock()
        {
            try
            {
                return _context.Wines.Where(w => w.Stock > 0);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public int AddWine(Wine wine)
        {
            try
            {
                _context.Add(wine);
                _context.SaveChanges();
                return _context.Wines.Max(w => w.Id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void UpdateWineStock(int id, int stock) 
        {
            try
            {
                _context.Wines.Single(w => w.Id == id).Stock = stock;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<Wine> GetByVariety(string varierty)
        {
            try
            {
                _context.Wines.Where(w => w.Variety == varierty && w.Stock > 0);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
