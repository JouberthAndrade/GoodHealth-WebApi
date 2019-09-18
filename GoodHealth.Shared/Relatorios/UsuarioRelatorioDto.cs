using GoodHealth.Shared.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodHealth.Shared.Relatorios
{
    public class UsuarioRelatorioDto
    {
        public int TotalAtivos
        {
            get
            {
                return Usuarios.Where(x => x.Ativo).Count();
            }
        }
        public int TotalInativos
        {
            get
            {
                return Usuarios.Where(x => !x.Ativo).Count();
            }
        }

        public List<UsuarioDto> Usuarios { get; set; }
    }
}
