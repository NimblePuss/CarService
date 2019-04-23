using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BeetrootApi.Interfaces;
using BeetrootModels.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BeetrootTest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Create order.
        /// </summary>
        /// <param name="order">Order</param>
        [HttpPost("Create")]
        public ActionResult Create([FromBody] NewOrderDTO order)
        {
            _orderService.Create(order);
            return Ok();
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>IEnumerable orders</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<OrderDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAll([FromQuery]int skip = 0, [FromQuery]int take = 20)
        {
            return Ok(await _orderService.GetAll(skip, take));
        }


        /// <summary>
        /// Get  order by id
        /// </summary>
        /// <returns>order</returns>
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(OrderDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderDTO>> GetById([FromQuery]int orderId)
        {
            return Ok(await _orderService.GetById(orderId));
        }

        /// <summary>
        /// Gets all orders services.
        /// </summary>
        /// <returns>The all order services.</returns>
        /// <param name="orderId">Order identifier.</param>
        [HttpGet("GetOrderServices")]
        [ProducesResponseType(typeof(IEnumerable<ServiceDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetAllOrderServices([FromQuery]int orderId)
        {
            return Ok(await _orderService.GetAllServices(orderId));
        }

        [HttpDelete("Remove")]
        public async Task<ActionResult> Remove([FromQuery] int orderId)
        {
            await _orderService.Remove(orderId);
            return Ok();
        }
    }
}
