using System.Collections.Generic;
using AutoMapper;
using GoodHealth.CrossCutting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHealth.CroosCuttimg.Ioc
{
    public static class DependecyContext
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration, IList<Profile> profiles)
        {
            services.UsuarioConfigure(configuration);
            services.EmpresaConfigure(configuration);
            services.ProdutoConfigure(configuration);

            services.AddSingleton(ctx =>
            {
                var mapper = AutoMapperConfig.RegisterMappings(profiles);
                mapper.CompileMappings();
                return mapper.CreateMapper();
            });
        }
    }
}
