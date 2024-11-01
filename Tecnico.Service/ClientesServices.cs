using System.Linq.Expressions;
using Tecnico.Abstracions;
using Tecnico.Data.Models;
using Tecnico.Domain.DTO;

namespace Tecnico.Service
{
    public class ClientesServices : IClienteService
    {
        public Task<ClientesDTO> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistePrioridad(int Nombres, int tiempo, string Telefono)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Guardar(ClientesDTO cliente)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientesDTO>> Listar(Expression<Func<ClientesDTO, bool>> criterio)
        {
            throw new NotImplementedException();
        }
    }
}
