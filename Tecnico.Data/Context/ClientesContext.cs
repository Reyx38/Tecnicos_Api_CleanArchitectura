using Microsoft.EntityFrameworkCore;
using Tecnico.Data.Models;

namespace Tecnico.Data.Context
{
    internal class ClientesContext(DbContextOptions<ClientesContext> options) : DbContext(options)
    {
        public DbSet<Clientes> Clientes { get; set; } 
    }
}
