using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Routing;
using MyBestDataClassEver;
using Microsoft.Extensions.Logging;

namespace MySuperBestCalculatorEver {
    public class Startup {

        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddDataProtection();
            services.AddAuthorization();
            services.AddWebEncoders();
            services.AddAuthentication();


            services.AddSingleton<FileLogger>(p => new FileLogger("MySuper.log")); /*(provider => new FileLogger("/logfile.log"));*/
            services.AddScoped<CalcDataDal>();
            services.AddDotVVM<DotvvmStartup>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/error");
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            var dotvvmConfiguration = app.UseDotVVM<DotvvmStartup>(env.ContentRootPath);
            dotvvmConfiguration.AssertConfigurationIsValid();

            app.UseStaticFiles(new StaticFileOptions {
                FileProvider = new PhysicalFileProvider(env.WebRootPath)
            });

            app.UseEndpoints(endpoints => {
                endpoints.MapDotvvmHotReload();
            });
        }
    }
}
