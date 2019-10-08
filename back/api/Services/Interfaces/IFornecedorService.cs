using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<Fornecedor>> BuscarFornecedorAsync();

        Task<IEnumerable<Fornecedor>> pesquisarFornecedorAsync(string nomeFornecedor);

        Task<Fornecedor> InserirFornecedorAsync(Fornecedor Fornecedor);

        Task<Fornecedor> BuscarFornecedorAsync(int id);

        Task<Fornecedor> AtualizarFornecedorAsync(Fornecedor Fornecedor);

        Task ExcluirFornecedorAsync(Fornecedor Fornecedor);
    }
}
