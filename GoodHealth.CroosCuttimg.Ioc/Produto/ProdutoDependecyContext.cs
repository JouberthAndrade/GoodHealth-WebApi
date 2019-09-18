using GoodHealth.Data.Empresa.Repositories;
using GoodHealth.Domain.Produto.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHealth.CroosCuttimg.Ioc
{
    internal static class ProdutoDependecyContext
    {
        public static void ProdutoConfigure(this IServiceCollection services, IConfiguration configuration)
        {

        }
    }
}
