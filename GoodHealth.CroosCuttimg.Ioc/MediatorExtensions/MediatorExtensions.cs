using GoodHealth.CroosCuttimg.Ioc.Handles;
using GoodHealth.CroosCuttimg.Ioc.Handles.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GoodHealth.CroosCuttimg.Ioc.MediatorExtensions
{
    public static class  MediatorExtensions
    {
        public static void RegisterMediatorHandler(this IServiceCollection services)
        {
            services.AddScoped<IHandler, Handler>();
         //   services.AddMediatR(services);
        }

        public static void RegisterMediatorHandler(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddScoped<IHandler, Handler>();
            services.AddMediatR(assemblies);
        }
    }
}
