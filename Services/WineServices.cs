using Data.Repository;
using Data.Entities;
using Common.Models;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.CodeAnalysis;

namespace Services
{
    public class WineServices : IWineServices
    {
        public readonly IWineRepository _wineRepository;
        public WineServices(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public int AddWine(CreateWineDTO createWineDTO)
        {
            if (_wineRepository.GetWines().All(w => w.Name != createWineDTO.Name))
            {
                try
                {
                    int newWine = _wineRepository.AddWine(
                        new Wine
                        {
                            Name = createWineDTO.Name,
                            Variety = createWineDTO.Variety,
                            Year = createWineDTO.Year,
                            Region = createWineDTO.Region,
                            Stock = createWineDTO.Stock
                        }
                        );
                    return newWine;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<Wine> GetWines()
        {
            try
            {
                return _wineRepository.GetWines();
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
                _wineRepository.UpdateWineStock(id, stock);
            }
            catch
            {
                throw new Exception();
            }
        }

        public IEnumerable<Wine> GetByVariety(string variety)
        {
            try
            {
                return _wineRepository.GetByVariety(variety);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
