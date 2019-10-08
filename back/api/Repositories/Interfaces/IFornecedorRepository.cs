using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories.Interfaces
{
    interface IFornecedorRepository : IBaseRepository<Fornecedor>
    {
        Task<IEnumerable<Fornecedor>> pesquisarFornecedorAsync(string nomeFornecedor);
    }
}