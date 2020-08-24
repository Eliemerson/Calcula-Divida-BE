using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paschoalotto.Dominio.Repositorios.Interfaces.AcordoClient;
using Paschoalotto.Dominio.Repositorios.Interfaces.Proposta;
using Paschoalotto.Dominio.Service;
using Paschoalotto.Dominio.Service.Interfaces;
using Paschoalotto.Dominio.Transacoes;
using Paschoalotto.Repositorio.Database.Context;
using Paschoalotto.Repositorio.Database.Repositorios;
using Paschoalotto.Repositorio.Database.Transacoes;

namespace Paschoalotto.ProvadorDados.API.Ioc
{
    public static class ApplicationDependencyResolver
    {
        public static void GetDependencies(IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddServices(services);
            AddDbContext(services, configuration);
        }
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var conn = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PaschoalottoContext>(x =>
                            x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                           y => y.MigrationsHistoryTable("HistoryMigrations", "provedordados"))
                            );
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAcordoClientRepositorio, AcordoClientRepositorio>();
            services.AddScoped<IPropostaRepositorio, PropostaRepositorio>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IPropostaService, PropostaService>();
            services.AddScoped<IAcordoClientService, AcordoClientService>();
        }
    }
}
