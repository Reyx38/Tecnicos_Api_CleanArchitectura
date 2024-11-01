using System.Linq.Expressions;
using Tecnico.Domain.DTO;

namespace Tecnico.Abstracions
{
    public interface IClienteService
    {
        Task<bool> Guardar(ClientesDTO cliente);
        Task<bool> Eliminar(int clienteId);
        Task<ClientesDTO> Buscar(int id);
        Task<List<ClientesDTO>> Listar(Expression<Func<ClientesDTO, bool>> criterio);
        Task<bool> ExistePrioridad(int Nombres, int tiempo, string Telefono);
    }
}
