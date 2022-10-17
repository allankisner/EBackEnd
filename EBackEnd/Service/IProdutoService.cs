using EBackEnd.Models;

namespace EBackEnd.Service
{
    public interface IProdutoService
    {
        
            Task<IEnumerable<Produto>> GetProdutos();

            Task<Produto> GetProdutos(int produtoId);

            Task<IEnumerable<Produto>> GetProdutosByDsc(string dscProduto);

            Task CreateProduto(Produto produto);

            Task DeleteProduto(Produto produto);

            Task UpdateProduto(Produto produto);
        
    }
}
