using Flunt.Notifications;
using GoodHealth.Data.Shared.Events;
using GoodHealth.Shared.Shared.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.CroosCuttimg.Ioc.Command
{
    public interface ICommand<TCommandResult> :
        IMessage,
        IRequest<TCommandResult>
        where TCommandResult : ICommandResult
    {
        IReadOnlyCollection<Notification> Notifications { get; }
        bool Invalid { get; }
        bool Valid { get; }

        bool Offline { get; }

        void CreatedOffline();
        void Validate();
    }
}
