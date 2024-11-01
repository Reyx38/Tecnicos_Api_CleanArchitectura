using Microsoft.Extensions.DependencyInjection;
using Tecnico.Data.DI;
using Tecnico.Abstracions;


namespace Tecnico.Service.Di
{
    public static class ServicesRegistar
    {
        public static IServiceCollection RegistarServices(this IServiceCollection services)
        {
            services.RegisterDbContextFactory();
            services.AddScoped<IClienteService, ClientesService>();
            return services;
        }
    }

}
