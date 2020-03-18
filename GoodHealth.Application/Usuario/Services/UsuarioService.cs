using AutoMapper.Configuration;
using GoodHealth.Application.Usuario.Services.Interface;
using GoodHealth.Domain.Usuario.Repositories;
using GoodHealth.Dto.Login;
using GoodHealth.Shared.Enum;
using GoodHealth.Shared.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Usuario.Entities;

namespace GoodHealth.Application.Usuario
{
    public class UsuarioService : Service, IUsuarioService
    {
        private readonly IUsuarioReadRepository usuarioReadRepository;

        public UsuarioService(IUsuarioReadRepository usuarioReadRepository)
        {
            this.usuarioReadRepository = usuarioReadRepository;
        }

        public async Task<LoginDto> Authenticate(string username, string password)
        {
            var user = await this.usuarioReadRepository.FindByLoginSenha(username, password);
            TipoUsuario tipoUsuaro = TipoUsuario.Usuario;

            if (user == null)
                return new LoginDto() { Authenticated = false, Message = "Falha ao autenticar"};
            
            tipoUsuaro = user.TipoUsuario == "A" ? TipoUsuario.Administrador : TipoUsuario.Usuario;
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(LoginSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim("Store", Enums.GetDescriptionFromEnumValue(tipoUsuaro))
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.SetToken(tokenHandler.WriteToken(token));

            return new LoginDto()
            {
                Authenticated = true,
                Message = "Login realizado com sucesso",
                Created = DateTime.Now,
                Expiration = DateTime.UtcNow.AddDays(1),
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                Token = user.Token
            }; 
        }
    }
}
