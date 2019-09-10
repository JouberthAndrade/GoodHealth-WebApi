using Flunt.Validations;
using GoodHealth.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using Model = GoodHealth.Domain.Empresa.Entities;

namespace GoodHealth.Domain.Usuario.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public Guid? EmpresaId { get; private set; }

        public Model.Empresa Empresa { get; private set; }

        protected Usuario()
        {

        }

        public Usuario(string nome, string email, string telefone)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.CreateDate = DateTime.Now;

            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(nome, string.Empty, "Nome", "Nome do usuário obrigátorio.")
                .AreNotEquals(email, string.Empty, "Email", "E-mail do usuário obrigátorio.")
            );
        }

        public void Atualizar(string nome, string email, string telefone)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
        }

        public void SetNomeUsuario(string nome)
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

        public void SetEmpresa(Model.Empresa empresa)
        {
            if (empresa != null)
                this.Empresa = empresa;
        }
    }
}
