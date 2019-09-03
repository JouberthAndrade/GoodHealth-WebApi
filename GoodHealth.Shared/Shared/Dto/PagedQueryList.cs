using GoodHealth.Shared.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Shared.Dto
{
    public struct PagedQueryList
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<UsuarioDto> Items { get; set; }
    }
}
