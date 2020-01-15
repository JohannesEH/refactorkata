using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DddTactical.Commands
{
    public class ConfirmShoppingCartCommand : INotification {}

    public class ConfirmShoppingCartCommandHandler : INotificationHandler<ConfirmShoppingCartCommand>
    {
        public Task Handle(ConfirmShoppingCartCommand notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
