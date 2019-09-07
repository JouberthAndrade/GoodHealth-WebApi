using Flunt.Notifications;
using GoodHealth.Shared.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Commands
{
    public abstract class Command<TCommandResult> : Notifiable,
        ICommand<TCommandResult>
        where TCommandResult : ICommandResult
    {
        public DateTime Timestamp { get; }
        public string MessageType { get; }

        public bool Offline { get; private set; } = false;

        public string MessageOperation => GetType().FullName;

        public Command()
        {
            Timestamp = DateTime.Now;
            MessageType = GetType().Name;
            Offline = false;
        }

        public abstract void Validate();

        public void CreatedOffline()
        {
            this.Offline = true;
        }
    }
}
