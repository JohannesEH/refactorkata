using System;
using System.Collections.Generic;

namespace DddTactical.Domain
{
    public class ShoppingCart : IEntity
    {
        public Guid Id { get; set; }

        public Customer Customer { get; set; }

        public List<Product> Products { get; set; }

        public State State { get; set; }
    }

    public enum State
    {
        New,
        Confirmed,
        Abandoned
    }
}
