using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Data.Shared.Events
{
    public interface IMessage
    {
        string MessageType { get; }
        string MessageOperation { get; }
    }
}
