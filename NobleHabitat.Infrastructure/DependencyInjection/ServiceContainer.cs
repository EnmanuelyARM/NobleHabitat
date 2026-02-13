using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Infrastructure.Repositories;
using NobleHabitat.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext with SQL Server
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy("WebUI",
                    builder => builder
                    .WithOrigins("https://localhost:7165")                    
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyHeader());
            });


            // Register UnitOfWork and Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAgenteRepository, AgenteRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPropietarioRepository, PropietarioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IInmuebleRepository, InmuebleRepository>();
            services.AddScoped<IOficinaRepository, OficinaRepository>();
            services.AddScoped<IZonaRepository, ZonaRepository>();
            services.AddScoped<ICaracteristicaInmuebleRepository, CaracteristicaInmuebleRepository>();
            services.AddScoped<IEstanciaRepository, EstanciaRepository>();
            services.AddScoped<IVisitaRepository, VisitaRepository>();
            services.AddScoped<IOfertaRepository, OfertaRepository>();
            return services;
        }
    }
}
