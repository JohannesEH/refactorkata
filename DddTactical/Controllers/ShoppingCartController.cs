using System;
using DddTactical.Domain;
using DddTactical.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DddTactical.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private ShoppingCartRepository shoppingCartRepository;

        public ShoppingCartController()
        {
            shoppingCartRepository = new ShoppingCartRepository();
        }

        [HttpGet("{id}")]
        public ActionResult<ShoppingCart> Get(Guid id)
        {
            var cart = shoppingCartRepository.Find(id);
            return cart == null ? NotFound() : (ActionResult<ShoppingCart>)Ok(cart);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ShoppingCart cart)
        {
            if (shoppingCartRepository.Find(cart.Id) != null)
            {
                return Conflict();
            }
            shoppingCartRepository.Save(cart);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ShoppingCart cart)
        {
            var existingCart = shoppingCartRepository.Find(id);
            if (existingCart == null)
                return NotFound();

            if (cart.State != State.Confirmed)
                return BadRequest("Cart can only be confirmed.");

            var service = new ShoppingService();

            service.ConfirmCart(cart);

            shoppingCartRepository.Save(cart);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingCart = shoppingCartRepository.Find(id);
            if (existingCart == null)
                return NotFound();
            existingCart.State = State.Abandoned;

            shoppingCartRepository.Save(existingCart);
            return Ok();
        }
    }
}
