using CoffeeShop.BusinessEntity.Entities;
using CoffeeShop.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoffeeShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICrudService<Coffee> coffeeService;

        public CoffeeController(ICrudService<Coffee> coffeeService)
        {
            this.coffeeService = coffeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.coffeeService.GetAll().ConfigureAwait(false);
            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Coffee coffee)
        {
            coffee.CreationDate = DateTime.Now;
            coffee.IsDeleted = false;

            await this.coffeeService.Upsert(coffee).ConfigureAwait(false);
            return this.Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Coffee coffee)
        {
            await this.coffeeService.Upsert(coffee).ConfigureAwait(false);
            return this.Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.coffeeService.Delete(id).ConfigureAwait(false);
            return this.Ok();
        }
    }
}