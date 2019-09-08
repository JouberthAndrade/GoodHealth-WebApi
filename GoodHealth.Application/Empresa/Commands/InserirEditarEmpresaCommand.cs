using Flunt.Validations;
using GoodHealth.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Application.Empresa.Commands
{
    public class InserirEditarEmpresaCommand : Command<CommandResult>
    {
        public Guid? Id { get; set; }

        public string Nome { get; set; }


        public override void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, "Nome", "O nome é obrigatório")
                .HasMaxLen(Nome, 250, "Nome", "O nome deve ter no máximo 250 caracteres.")
            );
        }
    }
}
