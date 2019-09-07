using GoodHealth.CroosCuttimg.Ioc.Localizations;
using GoodHealth.CroosCuttimg.Ioc.MediatorExtensions;
using GoodHealth.Data.Shared.Context;
using GoodHealth.Data.Shared.Data;
using GoodHealth.Shared.Interfaces;
using GoodHealth.Shared.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

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
            services.RegisterJsonLocalization();


            services.AddScoped<IValidationResultBuilder, ValidationResultBuilder>();
            services.AddScoped<IDomainNotificationService, DomainNotificationService>();
        }

        public static void RegisterRepositoryDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<GlobalContext>(options =>
                options.EnableDetailedErrors(true)
                .UseSqlServer(connectionString, x => x.EnableRetryOnFailure()
                                                      .MaxBatchSize(500)
                                                      .UseRelationalNulls(true)), 128);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
