using System;
using System.Threading.Tasks;
using System.Web.Http;
using DDDPizza.ApplicationServices;
using DDDPizza.ViewModels;

namespace DDDPizza.Api.Controllers
{
    public class PizzaController : ApiController
    {

        private readonly IOrderService _orderService;

        public PizzaController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpPost]
        [Route("api/place/order")]
        public async Task<IHttpActionResult> PlacePizza([FromBody]OrderVm placeOrder)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _orderService.PlaceOrder(placeOrder);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return Ok(ex);
                }
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("api/orders")]
        public async Task<IHttpActionResult> GetOrders()
        {
            return Ok(_orderService.GetAllOrders());
        }

        [HttpGet]
        [Route("api/orders/{id}")]
        public async Task<IHttpActionResult> GetOrder(string id)
        {
            return Ok(await _orderService.GetOrderById(id));
        }

       
    }
}
