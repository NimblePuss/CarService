using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BeetrootApi.Interfaces;
using BeetrootModels.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeetrootApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }


        /// <summary>
        /// Get all cars
        /// </summary>
        /// <returns>IEnumerable cars</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<CarDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetAll([FromQuery]int skip = 0, [FromQuery]int take = 20)
        {
            return Ok(await _carService.GetAll(skip, take));
        }


        /// <summary>
        /// Get  car by id
        /// </summary>
        /// <returns>car</returns>
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(CarDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CarDTO>> GetById([FromQuery]int carId)
        {
            return Ok(await _carService.GetById(carId));
        }
    }
}
