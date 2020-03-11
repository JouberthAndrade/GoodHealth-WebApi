using Flunt.Validations;
using GoodHealth.Shared.Commands;
using System;

namespace GoodHealth.Application.Produto.Commands
{
    public class ExcluirProdutoCommand : Command<CommandResult>
    {
        public Guid Id { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .AreNotEquals(Id, Guid.Empty, "Id", "Id do produto é inválido.")
            );
        }
    }
}
