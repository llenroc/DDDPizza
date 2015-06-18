﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
using DDDPizza.ApplicationServices;
using DDDPizza.ViewModels;

namespace DDDPizza.Api.Controllers
{
    public class OrderController : ApiController
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("api/place/order")]
        public async Task<IHttpActionResult> PlacePizza([FromBody]OrderVm placeOrder)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var vm = await _orderService.PlaceOrderAsync(placeOrder);
                return Created(Url.Route("OrderById",new{ id = vm.Id}), vm);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/orders", Name="Orders")]
        public async Task<IHttpActionResult> GetOrders()
        {
            return Ok(await _orderService.GetAllOrdersAsync());
        }

        [HttpGet]
        [Route("api/orders/{id}", Name="OrderById")]
        public async Task<IHttpActionResult> GetOrder(string id)
        {
            return Ok(await _orderService.GetOrderByIdAsync(id));
        }

        [HttpGet]
        [Route("api/services", Name = "ServiceOptions")]
        public async Task<IHttpActionResult> GetServiceOptions()
        {
            return Ok(_orderService.GetServiceOptions());
        }


       
    }
}
