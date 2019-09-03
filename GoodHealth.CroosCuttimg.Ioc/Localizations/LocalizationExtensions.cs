using GoodHealth.CroosCuttimg.Ioc.Localizations.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoodHealth.CroosCuttimg.Ioc.Localizations
{
    public static class LocalizationExtensions
    {
        public static IServiceCollection RegisterJsonLocalization(this IServiceCollection services, string resourceFilesDirectory = "Resources")
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Resources");

            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] info = dir.GetFiles("*.json");

            if (info.Length == 0)
                throw new Exception("É necessário criar um arquivo de resources para tradução de mensagens.O padrão de nomenclatura deve seguir a cultura selecionada('pt-BR.json') ou 'default.json'.");

            services.AddJsonLocalization(options =>
            {
                options.ResourceFilesDirectory = resourceFilesDirectory;
            });

            services.AddOptions();

            services.AddSingleton<IJsonLocalization, DefaultJsonLocalization>();

            return services;
        }
    }
}
