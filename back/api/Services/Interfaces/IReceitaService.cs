using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IReceitaService
    {
        Task<IEnumerable<Receita>> BuscarReceitaAsync();

        Task<IEnumerable<Receita>> pesquisarReceitaAsync(string nomeReceita);

        Task<Receita> InserirReceitaAsync(Receita receita);

        Task<Receita> BuscarReceitaAsync(int id);

        Task<Receita> AtualizarReceitaAsync(Receita receita);

        Task ExcluirReceitaAsync(Receita receita);
    }
}
