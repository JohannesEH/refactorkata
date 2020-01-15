using System;
using System.Collections.Generic;

namespace DddTactical.Domain
{
    public class ShoppingCart : IEntity
    {
        public Guid Id { get; private set; }

        public Guid CustomerId { get; private set; }

        public List<Guid> ProductIds { get; private set; }

        public IState State { get; private set; }

        public void Confirm()
        {
            this.State = new ConfirmedState();
        }
    }

    public interface IState {}

    public class NewState : IState {}

    public class ConfirmedState : IState {}

    public class AbandonedState : IState {}
}
