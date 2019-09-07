using Flunt.Validations;
using GoodHealth.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Application.Usuario.Commands
{
    public class ExcluirUsuarioCommand : Command<CommandResult>
    {
        public Guid Id { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .AreNotEquals(Id, Guid.Empty, "Id", "Id Usuário é inválido.")
            );
        }
    }
}
