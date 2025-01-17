﻿using GoodHealth.Shared.Empresa;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Usuario
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string NomeEmpresa { get; set; }

        public bool Ativo { get; set; }

        public EmpresaDto Empresa { get; set; }

    }
}
