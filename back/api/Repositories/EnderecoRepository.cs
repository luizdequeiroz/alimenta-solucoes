using api.Models;
using api.Repositories.Interfaces;

namespace api.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}