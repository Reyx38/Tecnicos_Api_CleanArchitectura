using Microsoft.AspNetCore.Mvc;
using Tecnico.Abstracions;
using Tecnico.Data.Models;
using Tecnico.Domain.DTO;
using Tecnico.Service;

namespace RegistrosTecnicos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService ClienteService) // Asegúrate de usar la interfaz  
        {
            _clienteService = ClienteService;
        }
        // GET: api/Clientes

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientesDTO>>> GetClientes()
        {
            return await _clienteService.Listar(p => true);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientesDTO>> GetCliente(int id)
        {
            return await _clienteService.Buscar(id);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientes(int id, ClientesDTO clienteDto)
        {

            if (id != clienteDto.ClienteId)
            {
                return BadRequest();
            }
            await _clienteService.Guardar(clienteDto);
            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostPrioridades(ClientesDTO clienteDto)
        {
            await _clienteService.Guardar(clienteDto);

            return CreatedAtAction("GetClientes", new { id = clienteDto.ClienteId }, clienteDto);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            await _clienteService.Eliminar(id);
            return NoContent();
        }
    }
}
