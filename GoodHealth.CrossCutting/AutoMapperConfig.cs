using AutoMapper;
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

                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

        }
    }
}
