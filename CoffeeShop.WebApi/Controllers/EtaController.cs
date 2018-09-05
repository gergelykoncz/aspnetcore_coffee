using CoffeeShop.BusinessEntity.Dto;
using CoffeeShop.BusinessEntity.Enums;
using CoffeeShop.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoffeeShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtaController : ControllerBase
    {
        private readonly IEtaCalculator etaCalculator;

        public EtaController(IEtaCalculator etaCalculator)
        {
            this.etaCalculator = etaCalculator;
        }

        // GET api/values
        [HttpPost]
        public async Task<int> Post([FromBody] string value)
        {
            Coordinates userCoord = new Coordinates() { Latitude = 47.5048, Longitude = 19.04689 };
            Coordinates shopCoord = new Coordinates() { Latitude = 47.62033, Longitude = 19.04613 };
            return await this.etaCalculator.CalculateEta(userCoord, shopCoord, TransportationMode.Bicycle);
        }
    }
}
