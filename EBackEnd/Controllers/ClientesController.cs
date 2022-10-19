using EBackEnd.Models;
using EBackEnd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // retorna lista dos clientes
        [HttpGet(Name = "GET Cliente")]
        public async Task<ActionResult<IAsyncEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                var clientes = await _clienteService.GetClientes();

                return Ok(clientes);
            }
            catch
            {
                return BadRequest("Request Invalid");
            }
        }
        // retorna cliente pelo nome 
        [HttpGet("GetByName")]
        public async Task<ActionResult<IAsyncEnumerable<Cliente>>>
            GetClientesByName([FromQuery] string nmCliente)
        {
            try
            {
                var clientes = await _clienteService.GetClientesByName(nmCliente);

                if (clientes.Count() == 0)
                    return BadRequest("Nome Não Encontrado!");

                return Ok(clientes);
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }
        //retorna cliente pelo id 
        [HttpGet("{id:int}", Name = "GetCliente")]

        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            try
            {
                var cliente = await _clienteService.GetCliente(id);

                if (cliente == null)
                    return NotFound($"Não existe cliente com o id:{id}");

                return Ok(cliente);
            }
            catch
            {
                return BadRequest("Request invalido!");
            }
        }
        //Cria Cliente
        [HttpPost]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            try
            {
                await _clienteService.CreateCliente(cliente);

                return CreatedAtRoute(nameof(GetCliente), new { id = cliente.IdCliente }, cliente);
            }
            catch
            {
                return BadRequest("Request Invalido!");
            }
        }
        //Edita Cliente
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Cliente cliente)
        {
            try
            {
                if (cliente.IdCliente == id)
                {
                    await _clienteService.UpdateCliente(cliente);

                    return Ok($"Aluno com id={id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("dados não são validos");
                }
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }
        //Exclui Cliente
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var cliente = await _clienteService.GetCliente(id);

                if(cliente != null)
                {
                    await _clienteService.DeleteCliente(cliente);

                    return Ok("Cliente Excluido com sucesso!");
                }
                else 
                {
                    return NotFound("Cliente não encontrado!");
                }
            }
            catch
            {
                return BadRequest("Não Foi possivel excluir o cliente!");
            }
        }
    }
}
