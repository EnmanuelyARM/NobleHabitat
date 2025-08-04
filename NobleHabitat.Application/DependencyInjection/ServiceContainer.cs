using Microsoft.Extensions.DependencyInjection;
using NobleHabitat.Application.Services;
using NobleHabitat.Application.Interfaces;

namespace NobleHabitat.Application.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            // Example: services.AddTransient<IMyService, MyService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAgenteService, AgenteService>();
            services.AddScoped<IPropietarioService, PropietarioService>();
            services.AddScoped<IInmuebleService, InmuebleService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IOficinaService, OficinaService>();
            services.AddScoped<IVisitaService, VisitaService>();
            services.AddScoped<IZonaService, ZonaService>();
            services.AddScoped<IEstanciaService, EstanciaService>();
            services.AddScoped<ICaracteristicaInmuebleService, CaracteristicaInmuebleService>();
            services.AddScoped<IOfertaService, OfertaService>();
            return services;
        }

        //public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        //{
        //    // Register infrastructure services here
        //    // Example: services.AddSingleton<IMyRepository, MyRepository>();
        //    return services;
        //}

        //public static IServiceCollection AddDomainServices(this IServiceCollection services)
        //{
        //    // Register domain services here
        //    // Example: services.AddScoped<IMyDomainService, MyDomainService>();
        //    return services;
    }
}
