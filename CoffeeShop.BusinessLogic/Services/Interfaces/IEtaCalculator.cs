using CoffeeShop.BusinessEntity.Dto;
using CoffeeShop.BusinessEntity.Enums;
using System.Threading.Tasks;

namespace CoffeeShop.BusinessLogic.Services.Interfaces
{
    public interface IEtaCalculator
    {
        Task CalculateEta(Coordinates userCoordinate, Coordinates shopCoordinate, TransportationMode transportationMode);
    }
}
