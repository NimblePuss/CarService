using System;
using System.Collections.Generic;
using System.Linq;
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
    public class PersonController : ControllerBase
    {
        private readonly IPersonalInfoService _personService;

        public PersonController(IPersonalInfoService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Get all person
        /// </summary>
        /// <returns>IEnumerable person</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<PersonalInfoDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PersonalInfoDTO>>> GetAll([FromQuery]int skip = 0, [FromQuery]int take = 20)
        {
            return Ok(await _personService.GetAll(skip, take));
        }

        /// <summary>
        /// Get  person by id
        /// </summary>
        /// <returns>person</returns>
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(PersonalInfoDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PersonalInfoDTO>> GetById([FromQuery]int orderId)
        {
            return Ok(await _personService.GetById(orderId));
        }

        /// <summary>
        /// Change  person info
        /// </summary>
        /// <returns></returns>
        [HttpPut("Change")]
        public async Task<ActionResult<PersonalInfoDTO>> Change([FromBody]PersonalInfoDTO person)
        {
            await _personService.Edit(person);
            return Ok();
        }
        /// <summary>
        /// Remove person by id.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="personId">Order identifier.</param>
        [HttpDelete("Remove")]
        public async Task<ActionResult> Remove([FromQuery] int personId)
        {
            await _personService.Remove(personId);
            return Ok();
        }
    }
}
