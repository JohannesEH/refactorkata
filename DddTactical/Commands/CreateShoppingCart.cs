using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DddTactical.Commands
{
    public class CreateShoppingCartCommand : INotification {}

    public class CreateShoppingCartCommandHandler : INotificationHandler<CreateShoppingCartCommand>
    {
        public Task Handle(CreateShoppingCartCommand notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
