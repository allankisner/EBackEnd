using EBackEnd.Models;

namespace EBackEnd.Service
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetClientes();

        Task<Cliente> GetCliente(int clienteId);

        Task<IEnumerable<Cliente>> GetClientesByName(string nmCliente);

        Task CreateCliente(Cliente cliente);

        Task DeleteCliente(Cliente cliente);

        Task UpdateCliente(Cliente cliente);
    }
}
