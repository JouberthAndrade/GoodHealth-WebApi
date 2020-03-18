using GoodHealth.Shared.Commands.Interface;
using GoodHealth.Shared.Entitys.Interface;
using GoodHealth.Shared.Handles.Interface;
using MediatR;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Handles
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
