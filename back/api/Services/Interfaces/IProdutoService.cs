using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> InserirProdutoAsync(Produto produto);

        Task<Produto> BuscarProdutoAsync(int id);

        Task<Produto> AtualizarProdutoAsync(Produto produto);

        Task ExcluirProdutoAsync(Produto produto);

    }
}
