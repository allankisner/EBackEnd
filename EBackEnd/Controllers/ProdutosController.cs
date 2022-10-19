using EBackEnd.Models;
using EBackEnd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // retorna lista de produtos
        [HttpGet(Name = "GET Produto")]
        public async Task<ActionResult<IAsyncEnumerable<Produto>>> GetProddutos()
        {
            try
            {
                var produtos = await _produtoService.GetProdutos();

                return Ok(produtos);
            }
            catch
            {
                return BadRequest("Request Invalid");
            }
        }

        // retorna produto pela descrição 
        [HttpGet("GetByDsc")]
        public async Task<ActionResult<IAsyncEnumerable<Produto>>>
            GetProdutosByDsc([FromQuery] string dscProduto)
        {
            try
            {
                var produtos = await _produtoService.GetProdutosByDsc(dscProduto);

                if (produtos.Count() == 0)
                    return BadRequest("Nome Não Encontrado!");

                return Ok(produtos);
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }

        //retorna produto pelo id
        [HttpGet("{id:int}", Name = "GetProdutoId")]

        public async Task<ActionResult<Produto>> GetProdutos(int id)
        {
            try
            {
                var produto = await _produtoService.GetProdutos(id);

                if (produto == null)
                    return NotFound($"Não existe produto com o id:{id}");

                return Ok(produto);
            }
            catch
            {
                return BadRequest("Request invalido!");
            }
        }

        //Cria Produto
        [HttpPost]
        public async Task<ActionResult> Create(Produto produto)
        {
            try
            {
                await _produtoService.CreateProduto(produto);

                return CreatedAtRoute(nameof(GetProdutos), new { idProduto = produto.IdProduto }, produto);
                
            }
            catch
            {
                return BadRequest("Request Invalido!");
            }
        }

        //Edita Produto
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Produto produto)
        {
            try
            {
                if (produto.IdProduto == id)
                {
                    await _produtoService.UpdateProduto(produto);

                    return Ok($"Produto com id={id} foi atualizado com sucesso");
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

        //Exclui Produto
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var produto = await _produtoService.GetProdutos(id);

                if (produto != null)
                {
                    await _produtoService.DeleteProduto(produto);

                    return Ok("Produto Excluido com sucesso!");
                }
                else
                {
                    return NotFound("Produto não encontrado!");
                }
            }
            catch
            {
                return BadRequest("Não Foi possivel excluir o Produto!");
            }
        }

    }
}
