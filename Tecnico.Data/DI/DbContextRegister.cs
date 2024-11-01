using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tecnico.Data.Context;

namespace Tecnico.Data.DI
{
    public static class DbContextRegister
    {
        public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services)
        {
            services.AddDbContextFactory<ClientesContext>(o => o.UseSqlServer("Name=SqlConStr"));
            return services;
        }
    }
}
