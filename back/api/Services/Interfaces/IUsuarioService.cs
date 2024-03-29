using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> BuscarUsuariosAsync();

        Task<Usuario> BuscarUsuarioAsync(int id);

        Task<Usuario> InserirUsuarioAsync(Usuario usuario);

        Task<Usuario> AtualizarUsuarioAsync(Usuario usuario);

        Task ExcluirUsuarioAsync(Usuario usuario);

        Task<Usuario> BuscarUsuarioPorLoginESenhaAsync(string login, string senha);
        
        Task<Usuario> BuscarUsuarioPorLoginAsync(string login);

        Task<Usuario> AutenticarUsuarioAsync(Usuario usuario); 
    }
}