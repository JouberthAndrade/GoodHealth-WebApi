using GoodHealth.Shared.Entitys;
using System;
using Model = GoodHealth.Domain.Produto.Entities;
using ModelUsuario = GoodHealth.Domain.Usuario.Entities;

namespace GoodHealth.Domain.Usuario.Entities
{
    public class UsuarioProduto : Entity
    {
        public Guid UsuarioId { get; private set; }
        public Guid ProdutoId { get; private set; }

        public int Quantidade { get; private set; }
        public string FlagDia { get; private set; }
        public DateTime DataInico { get; private set; }
        public DateTime? DataFim { get; private set; }


        public ModelUsuario.Usuario Usuario { get;  set; }
        public Model.Produto Produto { get;  set; }

        protected UsuarioProduto()
        {

        }
        public UsuarioProduto(Usuario usuario, Model.Produto produto) : this()
        {
            this.Usuario = usuario;
            this.Produto = produto;
            this.UsuarioId = usuario.Id;
            this.ProdutoId = produto.Id;
        }
    }
}
