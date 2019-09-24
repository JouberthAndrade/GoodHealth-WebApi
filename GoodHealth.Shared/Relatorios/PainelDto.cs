using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Relatorios
{
    public class PainelDto
    {
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string FlagDia { get; set; }
        public int QtdDiaProduto { get; set; }
        public string Classe { get; set; }
    }
}
