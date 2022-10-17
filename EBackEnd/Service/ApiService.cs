using EBackEnd.Models;
using Newtonsoft.Json;

namespace EBackEnd.Service
{
    public class ApiService
    {
        private readonly string _baseUrl = "https://camposdealer.dev/Sites/TesteAPI/";

        public async Task<List<Produto>> GetProdutos()
        {
            var produtos = new List<Produto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();

                var res = await client.GetAsync("produto");

                if (res.IsSuccessStatusCode)
                {
                    var resposta = res.Content.ReadAsStringAsync().Result;

                    var stringResponse = JsonConvert.DeserializeObject<string>(resposta);

                    produtos = JsonConvert.DeserializeObject<List<Produto>>(stringResponse);
                }
            }

            return produtos;
        }

        public async Task<List<Cliente>> GetClientes()
        {
            var clientes = new List<Cliente>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();

                var res = await client.GetAsync("cliente");

                if (res.IsSuccessStatusCode)
                {
                    var resposta = res.Content.ReadAsStringAsync().Result;

                    var stringResponse = JsonConvert.DeserializeObject<string>(resposta);

                    clientes = JsonConvert.DeserializeObject<List<Cliente>>(stringResponse);
                }
            }

            return clientes;
        }

        public async Task<List<Venda>> GetVendas()
        {
            var vendas = new List<Venda>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();

                var res = await client.GetAsync("venda");

                if (res.IsSuccessStatusCode)
                {
                    var resposta = res.Content.ReadAsStringAsync().Result;

                    var stringResponse = JsonConvert.DeserializeObject<string>(resposta);

                    vendas = JsonConvert.DeserializeObject<List<Venda>>(stringResponse);
                }
            }

            return vendas;
            
        }
    }
}
