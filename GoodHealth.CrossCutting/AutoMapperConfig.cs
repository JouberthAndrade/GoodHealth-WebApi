using AutoMapper;
using GoodHealth.CrossCutting.Empresa.Mappings;
using GoodHealth.CrossCutting.Produto.Mappings;
using GoodHealth.CrossCutting.Usuario.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.CrossCutting
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings(IList<Profile> profiles)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UsuarioDomainToDto());
                cfg.AddProfile(new EmpresaDomainToDto());
                cfg.AddProfile(new ProdutoDomainToDto());

                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

        }
    }
}
