using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BeetrootApi.Interfaces;
using BeetrootModels.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeetrootApi.Controllers
{
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ISVCService _svcService;

        public ServiceController(ISVCService svcService)
        {
            _svcService = svcService;
        }

        /// <summary>
        /// Get all services
        /// </summary>
        /// <returns>IEnumerable service</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<ServiceDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetAll([FromQuery]int skip = 0, [FromQuery]int take = 20)
        {
            return Ok(await _svcService.GetAll(skip, take));
        }

        /// <summary>
        /// Get  service by id
        /// </summary>
        /// <returns>service</returns>
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(ServiceDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceDTO>> GetById([FromQuery]int orderId)
        {
            return Ok(await _svcService.GetById(orderId));
        }
    }
}
