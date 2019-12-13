using System;
using System.Collections.Generic;
using DddTactical.Domain;
using DddTactical.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DddTactical.Services
{
    [Route("api/ShoppingCart/{cartId}/[controller]")]
    [ApiController]
    public class LineItemsController : ControllerBase
    {
        private ShoppingCartRepository shoppingCartRepository;

        public LineItemsController()
        {
            shoppingCartRepository = new ShoppingCartRepository();
        }

        [HttpPost]
        public IActionResult Post([FromRoute] Guid cartId, [FromBody] IEnumerable<Product> lineItems)
        {
            var cart = shoppingCartRepository.Find(cartId);
            if (cart == null)
            {
                return NotFound();
            }

            var service = new ShoppingService();

            foreach(var item in lineItems)
            { 
                service.AddProductToCart(cart, item);
            }
            shoppingCartRepository.Save(cart);
            return Ok();
        }
    }
}
