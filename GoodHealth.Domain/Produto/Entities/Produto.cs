using GoodHealth.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using ModelUsuario = GoodHealth.Domain.Usuario.Entities;


namespace GoodHealth.Domain.Produto.Entities
{
    public class Produto : Entity
    {
        private readonly List<ModelUsuario.UsuarioProduto> usuarioProdutos = new List<ModelUsuario.UsuarioProduto>();

        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }

        public List<ModelUsuario.UsuarioProduto> UsuarioProdutos => usuarioProdutos;

        protected Produto()
        {

        }
        public Produto(string descricao, decimal valor)
        {
            Descricao = descricao;
            Valor = valor;
        }

        public void Atualizar(string descricao, decimal valor)
        {
            this.Descricao = descricao;
            this.Valor = valor;
        }

        public void Atualizar(decimal valor)
        {
            this.Valor = valor;
        }

    }
}
