using GoodHealth.Data.Usuario.Repositories;
using GoodHealth.Domain.Usuario.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHealth.CroosCuttimg.Ioc
{
    internal static class UsuarioDependecyContext
    {
        public static void UsuarioConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IUsuarioReadRepository), typeof(UsuarioReadRepository));
            services.AddScoped(typeof(IUsuarioWriteRepository), typeof(UsuarioWriteRepository));
            
        }
    }
}
