using Flunt.Validations;
using GoodHealth.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Application.Usuario.Commands
{
    public class InserirEditarUsuarioCommand : Command<CommandResult>
    {
        public Guid? Id { get; set; }
        public Guid? IdEmpresa { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, "Nome", "O nome é obrigatório")
                .HasMaxLen(Nome, 250, "Nome", "O nome deve ter no máximo 250 caracteres.")
                .HasMaxLen(Email ?? "", 200, "Email", "O email deve ter no máximo 200 caracteres.")
            );
        }
    }
}
