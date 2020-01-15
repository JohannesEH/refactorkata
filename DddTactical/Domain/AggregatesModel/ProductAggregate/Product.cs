using System;

namespace DddTactical.Domain
{
    public class Product : IEntity
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public float Weight { get; private set; }
    }
}