using GoodHealth.Shared.Commands.Interface;
using GoodHealth.Shared.Handles.Interface;
using GoodHealth.Shared.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GoodHealth.Shared.CommandHandle
{
    public abstract class CommandHandler<TCommand, TCommandResult> : BaseHandle,
                   IRequestHandler<TCommand, TCommandResult>
                   where TCommand : ICommand<TCommandResult>
                   where TCommandResult : ICommandResult, new()
    {

        #region [ Private Properties ]

        protected IDomainNotificationService _notificationService;

        #endregion

        #region [ Constructor ]
        public CommandHandler(IHandler handler, IDomainNotificationService notificationService) : base(handler)
        {
            _notificationService = notificationService;
        }

        #endregion

        #region [ Methods ]
        public abstract Task<TCommandResult> HandleCommand(TCommand command);

        public virtual Task PostHandle() { return Task.FromResult(0); }

        public async Task<TCommandResult> Handle(TCommand request, CancellationToken cancellationToken)
        {
            //Fail Fast Validation
            request.Validate();

            if (request.Invalid)
            {
                AddCommandNotifications(request.Notifications);
                await Notify(Notifications);
                return new TCommandResult();
            }

            //Execução da implementação
            var result = await HandleCommand(request);

            if (!result.Success && !string.IsNullOrEmpty(result.Message))
                AddNotification("result", result.Message);

            await Notify(Notifications);

            //await RaiseEvents();

            if (!_notificationService.HasNotifications())
                await this.PostHandle();

            return result;
        }


        #endregion
    }
}
