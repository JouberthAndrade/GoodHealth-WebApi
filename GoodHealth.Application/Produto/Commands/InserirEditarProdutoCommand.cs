using Flunt.Validations;
using GoodHealth.Shared.Commands;
using System;

namespace GoodHealth.Application.Produto.Commands
{
    public class InserirEditarProdutoCommand : Command<CommandResult>
    {
        public Guid? Id { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Descricao, "Nome", "O nome é obrigatório")
                .HasMaxLen(Descricao, 250, "Nome", "O nome deve ter no máximo 250 caracteres.")
                .IsLowerThan(0, Valor, "Valor", "O valor não pode ser menor que 0")
            );
        }
    }
}
