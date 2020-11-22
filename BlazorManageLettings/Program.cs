using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorManageLettings.Services;
using Blazored.Toast;

namespace BlazorManageLettings
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            const string apiUrl = "https://lettings-manager.azurewebsites.net";

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredToast();
            builder.Services.AddHttpClient<IHouseSevices, HouseSevices>(client =>
            {
                client.BaseAddress = new Uri(apiUrl);
            });
            builder.Services.AddHttpClient<ILandlordServices, LandlordServices>(client =>
            {
                client.BaseAddress = new Uri(apiUrl);
            });

            await builder.Build().RunAsync();
        }
    }
}
