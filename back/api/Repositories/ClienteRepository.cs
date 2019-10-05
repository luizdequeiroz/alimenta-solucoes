using api.Models;
using api.Repositories.Interfaces;

namespace api.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}