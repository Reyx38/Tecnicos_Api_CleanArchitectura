using System.ComponentModel.DataAnnotations;

namespace Tecnico.Domain.DTO
{
    public class ClientesDTO
    {
        public int ClienteId { get; set; }

        public string? Nombres { get; set; }

        public string? Telefono { get; set; }
    }
}
