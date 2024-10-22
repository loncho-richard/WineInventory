using Common.Enum;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Services;

namespace WineInventory.Controllers
{
    [Route("api/wine")]
    [ApiController]
    public class WineController : ControllerBase
    {
        public readonly IWineServices _wineServices;
        public WineController(IWineServices wineServices)
        {
            _wineServices = wineServices;
        }

        [HttpPost]
        public IActionResult AddWine([FromBody] CreateWineDTO wineDTO)
        {
            if (wineDTO == null)
                return BadRequest("The body request is null");

            try
            {
                _wineServices.AddWine(wineDTO);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("This wine already exists");
            }
            return Created("Location", "Resource");
        }

        [HttpGet]
        public IActionResult GetWines()
        {
            try
            {
                return Ok(_wineServices.GetWines());
            }
            catch (Exception)
            {
                throw new Exception("cannot serve information");
            }
        }

        [HttpGet]
        [Route("variety/{variety}")]
        public IActionResult GetByVariety([FromRoute] string variety)
        {
            try
            {
                return Ok(_wineServices.GetByVariety(variety));
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPut]
        [Route("update/id_wine")]
        public IActionResult UpdateWine([FromRoute] int id, [FromRoute] int stock)
        {
            try
            {
                _wineServices.UpdateWine(id, stock);
                return Ok($"The new stock is: {stock} and the id wine is {id}");
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
