using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Shared.Commands
{
    public interface ICommandResult
    {
        bool Success { get; }
        string Message { get; set; }
        object Data { get; set; }
    }
}
