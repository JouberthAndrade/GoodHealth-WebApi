using MediatR;

namespace GoodHealth.Shared.Notifications
{
    public interface IDomainNotificationHandler : INotificationHandler<DomainNotification>
    {

    }
}
