using Flunt.Notifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Entitys.Interface
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
