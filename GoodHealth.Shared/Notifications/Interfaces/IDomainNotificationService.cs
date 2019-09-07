using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Notifications
{
    public interface IDomainNotificationService
    {
        void AddNotification(DomainNotification notification);
        Task AddNotificationAsync(DomainNotification notification);
        Task AddNotificationAsync(params DomainNotification[] notifications);
        List<DomainNotification> GetNotifications();
        Task<List<DomainNotification>> GetNotificationsAsync();
        bool HasNotifications();
        Task<bool> HasNotificationsAsync();
        void Clear();
        Task ClearAsync();
    }
}