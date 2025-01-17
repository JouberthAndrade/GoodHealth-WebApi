﻿using Flunt.Validations;
using GoodHealth.Shared.Commands;
using System;

namespace GoodHealth.Application.Empresa.Commands
{
    public class ExcluirEmpresaCommand : Command<CommandResult>
    {
        public Guid Id { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .AreNotEquals(Id, Guid.Empty, "Id", "Id Empresa é inválido.")
            );
        }
    }
}
