using GoodHealth.Shared.Interfaces;
using System;
using Model = GoodHealth.Domain.Usuario.Entities;

namespace GoodHealth.Domain.Usuario.Repositories
{
    public interface IUsuarioWriteRepository : IWriteRepository<Model.Usuario, Guid>
    {
    }
}
