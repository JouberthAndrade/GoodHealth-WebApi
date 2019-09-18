using GoodHealth.Shared.Produto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Usuario
{
    public class UsuarioProdutoDto : UsuarioDto
    {
        public int QtdDiasSemana {get; set;}
        public decimal ValorTotal { get; set; }

        public List<ProdutoDto> Produtos { get; set; }
       
    }
}
