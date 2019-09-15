using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> SelectAllAsync();
    }
}
