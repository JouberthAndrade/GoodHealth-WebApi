using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Notifications
{
    public interface IDomainNotificationHandler : INotificationHandler<DomainNotification>
    {

    }
}
