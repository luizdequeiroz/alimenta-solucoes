using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task AtualizarClienteAsync(Cliente cliente)
        {
            await clienteRepository.UpdateAsync(cliente);
        }

        public async Task<Cliente> BuscarClientePorIdAsync(int clienteId)
        {
            var cliente = await clienteRepository.FindOneAsync(new Cliente() { Id = clienteId });
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> BuscarClientesAsync()
        {
            var clientes = await clienteRepository.FindAllAsync();
            return clientes;
        }

        public async Task ExcluirClienteAsync(Cliente cliente)
        {
            await clienteRepository.DeleteAsync(cliente);
        }

        public async Task<Cliente> InserirClienteAsync(Cliente cliente)
        {
            await clienteRepository.InsertAsync(cliente);
            return cliente;
        }
    }
}