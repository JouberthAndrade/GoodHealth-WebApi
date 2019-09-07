using GoodHealth.Data.Shared.Events;
using GoodHealth.Shared.Entitys.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Notifications
{
    public class DomainNotification : IEvent
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public bool Required { get; private set; }
        public NotificationType Type { get; private set; }

        public DateTime Timestamp { get; }

        public string MessageType => GetType().Name;

        string IMessage.MessageType { get => GetType().Name; }

        public string SessionId => null;

        public Dictionary<string, object> Headers => new Dictionary<string, object>();

        public string MessageOperation => GetType().FullName;

        public DomainNotification(string key, string value, NotificationType type = NotificationType.Error)
        {
            Key = key;
            Value = value;
            Required = true;
            Type = type;
        }
    }

    public enum NotificationType
    {
        Success = 1,
        Alert,
        Error,
        Info
    }
}
