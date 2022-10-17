using EBackEnd.Models;
using EBackEnd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        
        protected readonly ApiService _apiService;

        public ApiController()
        {
            _apiService = new ApiService();
        }

        [HttpGet("Produtos")]
        public async Task<List<Produto>> ObterProdutos()
        {
            return await _apiService.GetProdutos();
        }

        [HttpGet("Clientes")]
        public async Task<List<Cliente>> ObterClientes()
        {
            return await _apiService.GetClientes();
        }

        [HttpGet("Vendas")]
        public async Task<List<Venda>> ObterVendas()
        {
            return await _apiService.GetVendas();
        }
    }
}

