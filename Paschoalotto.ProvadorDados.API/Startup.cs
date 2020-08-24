using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paschoalotto.ProvadorDados.API.Ioc;

namespace Paschoalotto.ProvadorDados.API
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;
        public Startup(IWebHostEnvironment env)
        {
            var binDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _configuration = new ConfigurationBuilder()
                      .SetBasePath(binDirectory)
                      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                      .AddEnvironmentVariables()
                      .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            ApplicationDependencyResolver.GetDependencies(services, _configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            PtBR();
            app.UseCors(o => o
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins(_configuration["PlataformaWebUrl"]));


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Paschoalotto API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void PtBR()
        {
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
