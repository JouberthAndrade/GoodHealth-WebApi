using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Empresa
{
    public class EmpresaDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Endereco { get;  set; }
        public string Telefone { get;  set; }
        public bool Ativo { get; set; }
    }
}
