using GoodHealth.Shared.Commands.Interface;
using GoodHealth.Shared.Entitys.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Handles.Interface
{
    public interface IHandler
    {
        Task<TCommandResult> SendCommand<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommand<TCommandResult>
            where TCommandResult : ICommandResult;
        Task RaiseEvent<T>(T @event) where T : IEvent;

    }
}
