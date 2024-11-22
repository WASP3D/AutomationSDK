using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BeeSys.Wasp3D.WaspWebServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Build configuration from appsettings.json to get hosting settings
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
            var selfhosted = config.GetSection("SelfHosted");
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Configure Kestrel server if self-hosted mode is enabled
            if (string.Compare(selfhosted.Value, "true", true) == 0)
            {
                //configure Kestrel server to listen on a specified port
                builder.WebHost.ConfigureKestrel(opts =>
            {
                // Get HTTP port from configuration
                var httpport = config.GetSection("HostingServer:Http:Port");

                // Listen on specified HTTP port for any IP address
                opts.ListenAnyIP(int.Parse(httpport.Value));                    
                    
            });
            }
            else
            {
                builder.WebHost.UseIISIntegration();        
            }
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");                   
            }
            app.UseHsts();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();            
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {

               });

    }
}
