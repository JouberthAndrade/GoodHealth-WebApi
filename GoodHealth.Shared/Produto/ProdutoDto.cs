using System;

namespace GoodHealth.Shared.Produto
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string FlagDia { get; set; }
        public string DiaSemana { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int QtdNaSemana { get; set; }
    }
}