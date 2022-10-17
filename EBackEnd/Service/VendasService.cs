using EBackEnd.Data;
using EBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EBackEnd.Service
{
    public class VendasService : IVendaService
    {
        private readonly EwaveDbContext _context;

        public VendasService(EwaveDbContext context)
        {
            _context = context;
        }

        // Lista as Vendas
        public async Task<IEnumerable<Venda>> GetVendas()
        {
            try
            {
                return await _context.Vendas
                    .Include(i => i.Cliente)
                    .Include(i => i.Produto)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        //Pega Vendas pela descrição do produto 
        public async Task<IEnumerable<Venda>> GetVendasByProduto(string DscProduto)
        {
            IEnumerable<Venda> vendas;
            if (!string.IsNullOrWhiteSpace(DscProduto))
            {
                vendas = (IEnumerable<Venda>)await _context.Produtos.Where(i => i.DscProduto.Contains(DscProduto))
                .ToListAsync();
            }
            else
            {
                vendas = await GetVendas();
            }

            return vendas;
        }

        //Pega Venda pelo Id
        public async Task<Venda> GetVenda(int vendaId)
        {
            var venda = await _context.Vendas.FindAsync(vendaId);

            return venda;
        }

        //Cria Venda 
        public async Task CreateVenda(Venda venda)
        {

            //Encontra o Produto
            var produto = await _context.Produtos.Where(p => p.IdProduto == venda.idProduto)
                         .FirstOrDefaultAsync();

            if (produto == null)
                throw new Exception("Não foi possível encontrar o Produto");

            //Encontra o Cliente
            var cliente = await _context.Clientes.Where(c => c.IdCliente == venda.idCliente)
                         .FirstOrDefaultAsync();

            if (cliente == null)
                throw new Exception("Não foi possível encontrar o Cliente");

            //Cria nova venda.
            var newVenda = new Venda
            {
                idCliente = cliente.IdCliente,
                idProduto = produto.IdProduto,
                qtdVenda = venda.qtdVenda,
                vlrUnitarioVenda = produto.VlrUnitario,
                dthVenda = DateTime.Now,
                vlrTotalVenda = produto.VlrUnitario * venda.qtdVenda
            };


            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            
        }

        // Atualiza Venda na Tabela
        public async Task UpdateVenda(Venda venda)
        {
            _context.Entry(venda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //Deleta Venda
        public async Task DeleteVenda(Venda venda)
        {
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
        }

        //Vendas da API

        public async Task GetDataApi()
        {

            var vendasApi = new ApiService();

            var vendas = await vendasApi.GetVendas();

            foreach(var venda in vendas )
            {
                if (!_context.Vendas.Any(i => i.IdVenda == i.IdVenda))
                {
                    _context.Vendas.Add(venda);
                }

                await _context.SaveChangesAsync();

            }

        }
    }

}


