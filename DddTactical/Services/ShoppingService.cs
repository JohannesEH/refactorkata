using DddTactical.Domain;
using System;
using System.Linq;

namespace DddTactical.Services
{
    public class ShoppingService
    {
        public void ConfirmCart(ShoppingCart cart)
        {
            cart.State = State.Confirmed;
        }

        public void AddProductToCart(ShoppingCart cart, Product product)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (cart.State == State.New)
            {
                cart.Products.Add(product);
            }
            else throw new Exception("Cannot add product to cart");
        }

        public decimal CalculatePrice(ShoppingCart cart)
        {
            switch (cart.State)
            {
                case State.New:
                    return cart.Products.Sum(f => f.Price);
                case State.Confirmed:
                    switch (cart.Customer.MemberShipStatus)
                    {
                        case MemberShipStatus.Basic:
                            return cart.Products.Sum(f => f.Price);
                        case MemberShipStatus.Gold:
                            return cart.Products.Sum(f => f.Price)*0.9M;
                        case MemberShipStatus.Platinum:
                            return cart.Products.Sum(f => f.Price)*0.75M;
                        default:
                            throw new Exception("Unkonwn membership status");
                    }
                default:
                    return 0M;
            }
        }
    }
}
