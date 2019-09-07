using GoodHealth.Data.Shared.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Entitys.Interface
{
    public interface IEvent : IMessage, INotification
    {
        DateTime Timestamp { get; }
        string SessionId { get; }
        Dictionary<string, object> Headers { get; }
    }
}
