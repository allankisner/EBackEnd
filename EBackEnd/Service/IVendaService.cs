using EBackEnd.Models;

namespace EBackEnd.Service
{
    public interface IVendaService
    {
        Task<IEnumerable<Venda>> GetVendas();

        Task<Venda> GetVenda(int idVenda);

        Task CreateVenda(Venda venda);

        Task DeleteVenda(Venda venda);

        Task UpdateVenda(Venda venda);
        
    }
}
