using GoodHealth.CroosCuttimg.Ioc.MediatorExtensions;
using GoodHealth.Data.Shared.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GoodHealth.CroosCuttimg.Ioc
{
    public static class IocExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Solução para não precisar injetar cada commandHanler
            AppDomain.CurrentDomain.Load(new AssemblyName("GoodHealth.Application"));
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            services.RegisterMediatorHandler(assemblies);
        }

        public static void RegisterRepositoryDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<GlobalContext>(options =>
                options.EnableDetailedErrors(true)
                .UseSqlServer(connectionString, x => x.EnableRetryOnFailure()
                                                      .MaxBatchSize(500)
                                                      .UseRelationalNulls(true)), 128);

        }
    }
}
