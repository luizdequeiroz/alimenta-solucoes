using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories.Interfaces
{
    interface IReceitaRepository : IBaseRepository<Receita>
    {
        Task<IEnumerable<Receita>> pesquisarReceitaAsync(string nomeReceita);
    }
}