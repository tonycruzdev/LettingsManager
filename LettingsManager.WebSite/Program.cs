using LettingsManager.WebSite.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LettingsManager.WebSite
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // step 5
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<LettingsManagerContext>();
                    await context.Database.MigrateAsync();
                    DbInitializer.Initialize(context, services.GetRequiredService<IWebHostEnvironment>());
                }
                catch (Exception ex)
                {

                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred during the migration.");
                }

            }

             host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
