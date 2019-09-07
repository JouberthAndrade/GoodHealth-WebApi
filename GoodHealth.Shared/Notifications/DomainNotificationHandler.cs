using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        private IDomainNotificationService _domainNotificationService;
              

        public DomainNotificationHandler(IDomainNotificationService domainNotificationService)
        {
            _domainNotificationService = domainNotificationService;
        }
        

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _domainNotificationService.AddNotification(notification);

            return Task.FromResult(0);
        }
    }
}
