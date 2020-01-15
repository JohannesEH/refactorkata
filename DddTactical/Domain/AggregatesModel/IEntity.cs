using System;

namespace DddTactical.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}