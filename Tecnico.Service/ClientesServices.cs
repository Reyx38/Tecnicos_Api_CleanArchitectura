using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tecnico.Abstracions;
using Tecnico.Data.Context;
using Tecnico.Data.Models;
using Tecnico.Domain.DTO;

namespace Tecnico.Service
{
    public class ClientesService(IDbContextFactory<ClientesContext> DbFactory) : IClienteService
    {
        private async Task<bool> Existe(int clienteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Clientes.AnyAsync(e => e.ClienteId == clienteId);
        }
        public async Task<ClientesDTO> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var Cliente = await contexto.Clientes
                .Where(e => e.ClienteId == id)
                .Select(p => new ClientesDTO()
                {
                    ClienteId = p.ClienteId,
                    Telefono = p.Telefono,
                    Nombres = p.Nombres
                }).FirstOrDefaultAsync();

            return Cliente ?? new ClientesDTO();
        }

        public async Task<bool> Eliminar(int clienteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .Where(e => e.ClienteId == clienteId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> ExisteCliente(string nombres, int id, string Telefono)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .AnyAsync(e => e.ClienteId != id
                && e.Telefono == Telefono
                || e.Nombres.ToLower().Equals(nombres.ToLower()));
        }

        public async Task<bool> Guardar(ClientesDTO cliente)
        {
            if (!await Existe(cliente.ClienteId))
            {
                return await Insertar(cliente);
            }
            else
            {
                return await Modificar(cliente);
            }
        }

        public async Task<List<ClientesDTO>> Listar(Expression<Func<ClientesDTO, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .Select(c => new ClientesDTO()
                {
                    ClienteId = c.ClienteId,
                    Nombres = c.Nombres,
                    Telefono = c.Telefono
                })
                .Where(criterio)
                .ToListAsync();
        }

        private async Task<bool> Insertar(ClientesDTO clientesDTO)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var Cliente = new Clientes()
            {
                ClienteId = clientesDTO.ClienteId,
                Nombres = clientesDTO.Nombres,
                Telefono = clientesDTO.Telefono
            };
            contexto.Clientes.Add(Cliente);
            var guardo = await contexto.SaveChangesAsync() > 0;
            clientesDTO.ClienteId = Cliente.ClienteId;
            return guardo;
        }
        private async Task<bool> Modificar(ClientesDTO clientesDTO)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var Cliente = new Clientes()
            {
                ClienteId = clientesDTO.ClienteId,
                Nombres = clientesDTO.Nombres,
                Telefono = clientesDTO.Telefono
            };
            contexto.Update(Cliente);
            var modificado = await contexto.SaveChangesAsync() > 0;
            return modificado;
        }
    }
}
