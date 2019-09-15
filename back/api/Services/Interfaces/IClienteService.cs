using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
    }
}
