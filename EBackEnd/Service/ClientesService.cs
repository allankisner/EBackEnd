using EBackEnd.Data;
using EBackEnd.Models;
using Microsoft.EntityFrameworkCore;


namespace EBackEnd.Service
{
    public class ClientesService : IClienteService
    {
        private readonly EwaveDbContext _context;

        public ClientesService(EwaveDbContext context)
        {
            _context = context;
        }

        // Lista os Clientes
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            try
            {
                return await _context.Clientes.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        //Pega Clientes pelo Nome (ou implementados sem filtro)
        public async Task<IEnumerable<Cliente>> GetClientesByName(string nmCliente)
        {
            IEnumerable<Cliente> clientes;
            if (!string.IsNullOrWhiteSpace(nmCliente))  
            {
                clientes = await _context.Clientes.Where(i => i.nmCliente.Contains(nmCliente))
                .ToListAsync();
            }
            else
            {
               clientes = await GetClientes();
            }

            return clientes;
        }

        //Pega Cliente pelo Id
        public async Task<Cliente> GetCliente(int clienteId)
        {
            var cliente = await _context.Clientes.FindAsync(clienteId);

            return cliente;
        }

        //Cria Cliente 
        public async Task CreateCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        // Atualiza Cliente na Tabela
        public async Task UpdateCliente(Cliente cliente)
        {
           _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //Deleta Cliente
        public async Task DeleteCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
