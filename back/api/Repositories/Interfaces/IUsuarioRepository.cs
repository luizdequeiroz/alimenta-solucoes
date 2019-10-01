using System.Threading.Tasks;
using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
         Task<Usuario> BuscarUsuarioPorLoginESenhaAsync(string login, string senha);

         Task<Usuario> BuscarUsuarioPorLoginAsync(string login);
    }
}