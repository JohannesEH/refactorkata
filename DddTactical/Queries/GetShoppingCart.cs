using DddTactical.Domain;
using DddTactical.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DddTactical.Queries
{
    public class GetShoppingCartQuery : IRequest<ShoppingCart>
    {
        public Guid Id { get; private set; }

        public GetShoppingCartQuery(Guid id)
        {
            this.Id = id;
        }
    }

    public class GetShoppingCartHandler : IRequestHandler<GetShoppingCartQuery, ShoppingCart>
    {
        private readonly ShoppingCartRepository repo;

        public GetShoppingCartHandler(ShoppingCartRepository repo)
        {
            this.repo = repo;
        }

        public async Task<ShoppingCart> Handle(GetShoppingCartQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(repo.Get(request.Id));
        }
    }
}
