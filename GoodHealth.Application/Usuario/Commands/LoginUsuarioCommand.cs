using Flunt.Validations;
using GoodHealth.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;


namespace GoodHealth.Application.Usuario.Commands
{
    public class LoginUsuarioCommand : Command<CommandResult>
    {
        public string Login { get; set; }

        public string Senha { get; set; }
        public override void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Login, "Login", "O login é obrigatório")
            );
        }
    }
}
