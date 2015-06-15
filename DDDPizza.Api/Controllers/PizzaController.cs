using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using DDDPizza.Api.Factories;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;
using DDDPizza.ViewModels;

namespace DDDPizza.Api.Controllers
{
    public class PizzaController : ApiController
    {

        private readonly IPizzaRepository _pizzaRepository;
        private readonly IViewModelFactory _viewModelFactory;

        public PizzaController(IPizzaRepository pizzaRepository, IViewModelFactory viewModelFactory)
        {
            _pizzaRepository = pizzaRepository;
            _viewModelFactory = viewModelFactory;
        }


        [HttpPost]
        [Route("api/place/order")]
        public async Task<IHttpActionResult> PlacePizza([FromBody]OrderVm placeOrder)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var vm = _viewModelFactory.CreateOrder(placeOrder);
                    var result = _pizzaRepository.Add(vm);
                    return Ok(result);
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
            var result = await _pizzaRepository.GetAll();
            var vm = _viewModelFactory.CreateFromVm<List<Order>, List<OrderVm>>(result.OrderByDescending(x => x.DateTimeStamp).ToList());
            return Ok(vm);
        }

        [HttpGet]
        [Route("api/orders/{id}")]
        public async Task<IHttpActionResult> GetOrder(string id)
        {
            return Ok(await _pizzaRepository.GetById(Guid.Parse(id)));
        }

        [HttpPost]
        [Route("api/orders")]
        public async Task<IHttpActionResult> InsertOrder([FromBody]Order order)
        {
            //var returnOrder = await _pizzaRepository.Add(order);
            //return Created("", returnOrder);
            return Ok();
        }


     

    }
}
