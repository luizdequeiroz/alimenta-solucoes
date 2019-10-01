using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Repositories.Interfaces;
using api.Repositories.Scripts;
using Dapper;

namespace api.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<Usuario> BuscarUsuarioPorLoginESenhaAsync(string login, string senha)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                var sql = UsuarioScripts.BuscarUsuarioPorLoginESenhaScript;
                var retorno = await conexao.QueryAsync<Usuario>(sql, new { Login = login, Senha = senha });
                return retorno.FirstOrDefault();
            }
        }

        public async Task<Usuario> BuscarUsuarioPorLoginAsync(string login)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                var sql = UsuarioScripts.BuscarUsuarioPorLoginScript;
                var retorno = await conexao.QueryAsync<Usuario>(sql, new { Login = login });
                return retorno.FirstOrDefault();
            }
        }
    }
}