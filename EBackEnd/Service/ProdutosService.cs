using EBackEnd.Data;
using EBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace EBackEnd.Service
{
    public class ProdutosService : IProdutoService
    {
        private readonly EwaveDbContext _context;

        public ProdutosService(EwaveDbContext context)
        {
            _context = context;
        }

        // Lista os Produtos
        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            try
            {
                return await _context.Produtos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        //Pega Produtos pelo Nome (ou implementados sem filtro)
        public async Task<IEnumerable<Produto>> GetProdutosByDsc(string dscProduto)
        {
            IEnumerable<Produto> produtos;
            if (!string.IsNullOrWhiteSpace(dscProduto))
            {
                produtos = await _context.Produtos.Where(i => i.DscProduto.Contains(dscProduto))
                .ToListAsync();
            }
            else
            {
                produtos = await GetProdutos();
            }

            return produtos;
        }

        //Pega Produto pelo Id
        public async Task<Produto> GetProdutos(int produtoId)
        {
            var produto = await _context.Produtos.FindAsync(produtoId);

            return produto;
        }

        //Cria Produto
        public async Task CreateProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        // Atualiza Produto na Tabela
        public async Task UpdateProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //Deleta Produto
        public async Task DeleteProduto(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
