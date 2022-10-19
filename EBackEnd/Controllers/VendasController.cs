using EBackEnd.Models;
using EBackEnd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private IVendaService _vendaService;

        public VendasController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        // retorna lista dos vendas
        [HttpGet(Name = "GET Venda")]
        public async Task<ActionResult<IAsyncEnumerable<Venda>>> GetVendas()
        {
            try
            {
                var vendas = await _vendaService.GetVendas();

                return Ok(vendas);
            }
            catch
            {
                return BadRequest("Request Invalid");
            }
        }
       
        //retorna venda pelo id 
        [HttpGet("{id:int}", Name = "GetVenda")]

        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            try
            {
                var venda = await _vendaService.GetVenda(id);

                if (venda == null)
                    return NotFound($"Não existe venda com o id:{id}");

                return Ok(venda);
            }
            catch
            {
                return BadRequest("Request invalido!");
            }
        }
        //Cria Venda
        [HttpPost]
        public async Task<ActionResult> Create(Venda venda)
        {
            try
            {
                await _vendaService.CreateVenda(venda);

                return CreatedAtRoute(nameof(GetVenda), new { id = venda.IdVenda }, venda);
            }
            catch
            {
                return BadRequest("Request Invalido!");
            }
        }
        //Edita Venda
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Venda venda)
        {
            try
            {
                if (venda.IdVenda == id)
                {
                    await _vendaService.UpdateVenda(venda);

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
        //Exclui Venda
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var venda = await _vendaService.GetVenda(id);

                if (venda != null)
                {
                    await _vendaService.DeleteVenda(venda);

                    return Ok("Venda Excluido com sucesso!");
                }
                else
                {
                    return NotFound("Venda não encontrado!");
                }
            }
            catch
            {
                return BadRequest("Não Foi possivel excluir o venda!");
            }
        }     
        
    }
}
