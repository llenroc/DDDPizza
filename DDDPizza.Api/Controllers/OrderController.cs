using System;
using System.Threading.Tasks;
using System.Web.Http;
using DDDPizza.ApplicationServices;
using DDDPizza.ViewModels;
using Mindscape.Raygun4Net.WebApi;

namespace DDDPizza.Api.Controllers
{
    public class OrderController : BaseApiController
    {


        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        

        [HttpPost]
        [Route("api/order")]
        public async Task<IHttpActionResult> PlaceOrder([FromBody]OrderVm placeOrder)
        {

            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var vm = await _orderService.PlaceOrderAsync(placeOrder);
                return Created(Url.Route("OrderById", new { id = vm.Id }), vm);
            }
            catch (Exception ex)
            {
                new RaygunWebApiClient().SendInBackground(ex);
                return InternalServerError();
            }
         
        }

        [HttpGet]
        [Route("api/current/orders", Name = "CurrentOrders")]
        public async Task<IHttpActionResult> GetCurrentOrders()
        {
            return Ok(await _orderService.GetAllCurrentOrdersAsync());
        }

        [HttpGet]
        [Route("api/past/orders", Name = "PastOrders")]
        public async Task<IHttpActionResult> GetPastOrders()
        {
            return Ok(await _orderService.GetAllPastOrdersAsync());
        }

        [HttpGet]
        [Route("api/orders/{id}", Name="OrderById")]
        public async Task<IHttpActionResult> GetOrder(string id)
        {
            return Ok(await _orderService.GetOrderByIdAsync(id));
        }

        [HttpGet]
        [Route("api/orders/service/{type}", Name = "OrdersByServiceType")]
        public async Task<IHttpActionResult> GetOrdersByServiceType(string type)
        {
            return Ok(await _orderService.GetAllOrdersByServiceTypeAsync(type));
        }

        [HttpGet]
        [Route("api/services", Name = "ServiceOptions")]
        public async Task<IHttpActionResult> GetServiceOptions()
        {
            return Ok(_orderService.GetServiceOptions());
        }

        [HttpGet]
        [Route("api/orders/pending", Name = "PendingOrderCount")]
        public async Task<IHttpActionResult> GetPendingOrderCount()
        {
            return Ok(await _orderService.CountPendingOrders());
        }

       
    }
}
