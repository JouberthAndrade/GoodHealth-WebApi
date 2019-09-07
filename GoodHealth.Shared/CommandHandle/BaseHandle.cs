using Flunt.Notifications;
using GoodHealth.Shared.Entitys;
using GoodHealth.Shared.Entitys.Interface;
using GoodHealth.Shared.Handles.Interface;
using GoodHealth.Shared.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Shared.CommandHandle
{
    public abstract class BaseHandle : Notifiable
    {
        protected List<IEvent> _domainEvents;
        protected readonly IHandler _handler;

        protected bool _offline = false;

        public BaseHandle(IHandler handler)
        {
            _handler = handler;
            _domainEvents = new List<IEvent>();
        }

        protected void HandleEntity<TPrimaryKey>(IEntity<TPrimaryKey> entity)
        {
            /*
            if (entity is IAggregateRoot<TPrimaryKey>)
                _domainEvents.AddRange(((IAggregateRoot<TPrimaryKey>)entity).DomainEvents);

            if (entity is IOffline && _offline)
                ((IOffline)entity).CreatedOffline();*/

            //GetChildsNotification(entity);

            AddCommandNotifications(entity.Notifications);
        }

        protected async Task Notify(IReadOnlyCollection<Notification> notifications)
        {
            var notifyTasks = new List<Task>();
            foreach (var notification in notifications.Where(n => n != null))
            {
                notifyTasks.Add(_handler.RaiseEvent(new DomainNotification(notification.Property, notification.Message)));
            }

            await Task.WhenAll(notifyTasks);

            return;
        }


        private void GetChildsNotification<TPrimaryKey>(IEntity<TPrimaryKey> entity)
        {
            var properties = entity.GetType().GetProperties();

            foreach (var property in properties)
            {
                IReadOnlyCollection<Notification> notifications = new List<Notification>();
                if (property.PropertyType.IsSubclassOf(typeof(Entity)))
                {
                    property.GetType().GetProperty("Notifications").GetValue(notifications, null);
                    AddCommandNotifications(notifications);
                }
            }
        }

        protected void AddCommandNotifications(IReadOnlyCollection<Notification> notifications)
        {
            foreach (var notification in notifications.Where(n => n != null))
            {
                if (this.Notifications.Any(n => n.Message == notification.Message && n.Property == notification.Property))
                    return;
                else
                    AddNotification(notification);
            }
        }


        protected void HandleEntities<TPrimaryKey>(params IEntity<TPrimaryKey>[] entities)
        {
            foreach (var entity in entities)
            {
                HandleEntity(entity);
            }
        }

        
    }
}
