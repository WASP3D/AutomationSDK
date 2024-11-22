using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace BeeSys.Wasp3D.WaspWebServer
{
    public class Startup
    {
         
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRazorPages(); 
            

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                      policy.AllowAnyHeader();
                                      policy.AllowAnyMethod(); 
                                  });
            });

          

            services.AddControllersWithViews();
            services.AddMvc();
           
            services.AddSession(options =>
            {
                options.IOTimeout = TimeSpan.FromSeconds(60000);
                options.IdleTimeout = TimeSpan.FromSeconds(60000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


        }
         
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseDeveloperExceptionPage();
            //app.UseHttpsRedirection();
            app.UseHsts();
            app.UseStaticFiles();

            app.UseRouting();
           
            

            app.UseSession();

            app.UseCors(MyAllowSpecificOrigins);


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
               
            });
          
        }

      
    }
}
