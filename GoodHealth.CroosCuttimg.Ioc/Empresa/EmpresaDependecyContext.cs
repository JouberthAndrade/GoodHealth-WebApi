using GoodHealth.Data.Empresa.Repositories;
using GoodHealth.Domain.Empresa.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHealth.CroosCuttimg.Ioc
{
    internal static class EmpresaDependecyContext
    {
        public static void EmpresaConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IEmpresaReadRepository), typeof(EmpresaReadRepository));

        }
    }
}
