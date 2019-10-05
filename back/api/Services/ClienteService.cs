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
        
        private readonly IEnderecoRepository enderecoRepository;

        public ClienteService(IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository)
        {
            this.clienteRepository = clienteRepository;
            this.enderecoRepository = enderecoRepository;
        }

        public async Task AtualizarClienteAsync(Cliente cliente)
        {
            await clienteRepository.UpdateAsync(cliente);
        }

        public async Task<Cliente> BuscarClientePorIdAsync(int clienteId)
        {
            var cliente = await clienteRepository.FindOneAsync(new Cliente() { Id = clienteId });
            await PreencherEnderecosClienteAsync(cliente);

            return cliente;
        }

        public async Task<IEnumerable<Cliente>> BuscarClientesAsync()
        {
            var clientes = await clienteRepository.FindAllAsync();

            foreach (var cliente in clientes)
            {
                await PreencherEnderecosClienteAsync(cliente);
            }

            return clientes;
        }

        private async Task PreencherEnderecosClienteAsync(Cliente cliente)
        {
            if (cliente != null)
            {
                if (cliente.EnderecoId > 0)
                    cliente.Endereco = await enderecoRepository.FindOneAsync(new Endereco() { Id = cliente.EnderecoId });

                if (cliente.EnderecoEntregaId > 0)
                    cliente.EnderecoEntrega = await enderecoRepository.FindOneAsync(new Endereco() { Id = cliente.EnderecoEntregaId });
            }
        }

        public async Task DesativarClienteAsync(Cliente cliente)
        {
            cliente.DesativarCliente();
            await clienteRepository.UpdateAsync(cliente);
        }

        public async Task<Cliente> InserirClienteAsync(Cliente cliente)
        {
            await clienteRepository.InsertAsync(cliente);
            return cliente;
        }
    }
}