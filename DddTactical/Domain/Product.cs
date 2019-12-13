using System;

namespace DddTactical.Domain
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
    }
}