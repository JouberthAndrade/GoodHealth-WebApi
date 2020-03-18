using GoodHealth.Dto.Login;
using GoodHealth.Shared.Data;
using GoodHealth.Shared.Interfaces;
using GoodHealth.Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Usuario.Entities;

namespace GoodHealth.Application.Usuario.Services.Interface
{
    public interface IUsuarioService : IService
    {
        Task<LoginDto> Authenticate(string username, string password);
    }
}
