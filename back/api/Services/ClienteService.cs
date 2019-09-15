using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await clienteRepository.SelectAllAsync();
        }
    }
}
