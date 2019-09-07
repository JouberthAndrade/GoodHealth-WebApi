using GoodHealth.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using Model = GoodHealth.Domain.Empresa.Entities;

namespace GoodHealth.Domain.Usuario.Entities
{
    public class UsuarioEmpresa : Entity
    {
        public Guid UsuarioId { get; private set; }
        public Guid EmpresaId { get; private set; }


        public Usuario Usuario { get; private set; }
        public Model.Empresa Empresa { get; private set; }

        protected UsuarioEmpresa()
        {

        }
        public UsuarioEmpresa(Usuario usuario, Model.Empresa empresa)
        {
            this.Usuario = usuario;
            this.Empresa = empresa;
            this.UsuarioId = usuario.Id;
            this.EmpresaId = empresa.Id;
        }
    }
}
