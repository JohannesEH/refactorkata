using System;
using System.Threading.Tasks;
using DddTactical.Commands;
using DddTactical.Domain;
using DddTactical.Queries;
using DddTactical.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DddTactical.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator mediator;

        //private ShoppingCartRepository shoppingCartRepository;

        public ShoppingCartController(MediatR.IMediator mediator)
        {
            this.mediator = mediator;
            //shoppingCartRepository = new ShoppingCartRepository();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCart>> Get(Guid id)
        {
            var cart = await mediator.Send(new GetShoppingCartQuery(id));
            return cart == null ? NotFound() : (ActionResult<ShoppingCart>)Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShoppingCart cart)
        {
            if (await mediator.Send(new GetShoppingCartQuery(cart.Id)) != null)
            {
                return Conflict();
            }

            await mediator.Publish(new CreateShoppingCartCommand(cart));
            //shoppingCartRepository.Save(cart);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ShoppingCart cart)
        {
            var existingCart = await mediator.Send(new GetShoppingCartQuery(id));
            //var existingCart = shoppingCartRepository.Find(id);
            if (existingCart == null)
                return NotFound();

            if (typeof(cart.State) != ConfirmedState)
                return BadRequest("Cart can only be confirmed.");

            var service = new ShoppingService();

            cart.Confirm();
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
