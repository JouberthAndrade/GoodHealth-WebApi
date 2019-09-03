using GoodHealth.CroosCuttimg.Ioc.Command;
using GoodHealth.Domain.Shared.Interface;
using GoodHealth.Shared.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.CroosCuttimg.Ioc.Handles.Interface
{
    public interface IHandler
    {
        Task<TCommandResult> SendCommand<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommand<TCommandResult>
            where TCommandResult : ICommandResult;
        Task RaiseEvent<T>(T @event) where T : IEvent;

    }
}
