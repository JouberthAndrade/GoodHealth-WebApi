using GoodHealth.CroosCuttimg.Ioc.Command;
using GoodHealth.CroosCuttimg.Ioc.Handles.Interface;
using GoodHealth.Domain.Shared.Interface;
using GoodHealth.Shared.Shared.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.CroosCuttimg.Ioc.Handles
{
    public class Handler : IHandler
    {
        private readonly IMediator _mediator;
        public Handler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public Task RaiseEvent<T>(T @event) where T : IEvent
        {
            return Publish(@event);
        }

        public Task<TCommandResult> SendCommand<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommand<TCommandResult>
            where TCommandResult : ICommandResult
        {
            return _mediator.Send(command);
        }


        private Task Publish<T>(T message) where T : INotification
        {
            return _mediator.Publish(message);
        }

    }
}
