using Microsoft.EntityFrameworkCore;
using Tecnico.Data.Models;

namespace Tecnico.Data.Context
{
    public class ClientesContext(DbContextOptions<ClientesContext> options) : DbContext(options)
    {
        public DbSet<Clientes> Clientes { get; set; } 
    }
}
