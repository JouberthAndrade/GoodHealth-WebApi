using Flunt.Validations;
using GoodHealth.Shared.Entitys;
using System;
using System.Collections.Generic;
using Model = GoodHealth.Domain.Usuario.Entities;

namespace GoodHealth.Domain.Empresa.Entities
{
    public class Empresa : Entity
    {
        private readonly List<Model.Usuario> usuarios = new List<Model.Usuario>();


        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }

        public List<Model.Usuario> Usuarios => this.usuarios;

        protected Empresa()
        {

        }

        public Empresa(string nome)
        {
            this.Nome = nome;

            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(nome, string.Empty, "Nome", "Nome da Empresa obrigátorio.")
            );
        }
        public void Atualizar(string nome, string endereco, string telefone)
        {
            this.Nome = nome;
            this.Endereco = endereco;
            this.Telefone = telefone;
        }

        public void SetNomeEmpresa(string nome)
        {
            this.Nome = nome;
        }

        public void Delete()
        {
            this.Ativo = false;
            this.DeletedDate = DateTime.Now;
        }

        public void SetId(Guid id)
        {
            if (id != Guid.Empty)
                this.Id = id;
        }
    }
}
