using GoodHealth.Data.Shared.Context;
using GoodHealth.Domain.Usuario.Repositories;
using GoodHealth.Shared.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Model = GoodHealth.Domain.Usuario.Entities;


namespace GoodHealth.Data.Usuario.Repositories
{
    public class UsuarioWriteRepository : EntityBaseRepository<Model.Usuario, Guid>, IUsuarioWriteRepository
    {
        public UsuarioWriteRepository(GlobalContext dbcontext) : base(dbcontext)
        {
        }
    }
}
