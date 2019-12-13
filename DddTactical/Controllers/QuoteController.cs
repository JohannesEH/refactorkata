using DddTactical.Repository;
using DddTactical.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DddTactical.Controllers
{
    [Route("api/ShoppingCart/{cartId}/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private ShoppingCartRepository shoppingCartRepository;
        public QuoteController()
        {
            shoppingCartRepository = new ShoppingCartRepository();
        }


        [HttpGet("{id}")]
        public ActionResult<decimal> Get([FromRoute]Guid id)
        {
            var cart = shoppingCartRepository.Find(id);
            if (cart == null)
                return NotFound();
            var service = new ShoppingService();
            return service.CalculatePrice(cart);            
        }
    }
}
