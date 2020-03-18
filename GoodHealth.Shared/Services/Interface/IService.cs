using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Services.Interface
{
    public interface IService
    {
        IReadOnlyCollection<Notification> Notifications { get; }
        bool Invalid { get; }
        bool Valid { get; }
    }
}
