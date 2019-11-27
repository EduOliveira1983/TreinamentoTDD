using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreinamentoTDD.Dados.Contextos;
using TreinamentoTDD.Dados.Repositorios;
using TreinamentoTDD.Dominio.Interface;
using TreinamentoTDD.Dominio.Service;

namespace TreinamentoTDD.IoC
{
    public static class StartupIoC
    {
        public static void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration["DefaultConnection"]));

            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddScoped(typeof(ICursoRepositorio), typeof(CursoRepositorio));

            services.AddScoped<ArmazenadorCurso>();


        }

    }
}
