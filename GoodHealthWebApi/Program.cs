using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GoodHealthWebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(o => o.ValidateScopes = false)
                .ConfigureAppConfiguration((hostingContext, config) => {
                    config
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://localhost:5101")
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();
                
    }
}
