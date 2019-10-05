using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Services.Interfaces
{
    public interface IClienteService
    {
         Task<Cliente> InserirClienteAsync(Cliente cliente);

         Task<Cliente> BuscarClientePorIdAsync(int clienteId);

         Task<IEnumerable<Cliente>> BuscarClientesAsync();

         Task AtualizarClienteAsync(Cliente cliente);

         Task ExcluirClienteAsync(Cliente cliente);
    }
}