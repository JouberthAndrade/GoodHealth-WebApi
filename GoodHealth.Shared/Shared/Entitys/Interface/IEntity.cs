using Flunt.Notifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Domain.Shared.Interface
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; }
        [JsonIgnore]
        IReadOnlyCollection<Notification> Notifications { get; }
        [JsonIgnore]
        bool Invalid { get; }
        [JsonIgnore]
        bool Valid { get; }
    }
}
