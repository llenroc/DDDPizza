using System;
using System.Threading.Tasks;
using System.Web.Http;
using DDDPizza.DomainModels;
using DDDPizza.Interfaces;

namespace DDDPizza.Api.Controllers
{
    public class PizzaController : ApiController
    {

        private readonly IPizzaRepository _pizzaRepository;

        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        [HttpGet]
        [Route("api/orders")]
        public async Task<IHttpActionResult> GetOrders()
        {
            return Ok(await _pizzaRepository.GetAll());
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


        [HttpGet]
        [Route("api/toppings")]
        public async Task<IHttpActionResult> GetToppings()
        {
            return Ok(await _pizzaRepository.GetAllToppings());
        }

        [HttpGet]
        [Route("api/breads")]
        public async Task<IHttpActionResult> GetBreads()
        {
            return Ok(await _pizzaRepository.GetAllBreads());
        }

        [HttpGet]
        [Route("api/sauces")]
        public async Task<IHttpActionResult> GetSauses()
        {
            return Ok(await _pizzaRepository.GetAllSauces());
        }

        [HttpGet]
        [Route("api/sizes")]
        public async Task<IHttpActionResult> GetSizes()
        {
            return Ok(await _pizzaRepository.GetAllSizes());
        }

        [HttpGet]
        [Route("api/cheeses")]
        public async Task<IHttpActionResult> GetCheeses()
        {
            return Ok(await _pizzaRepository.GetAllCheeses());
        }

    }
}
