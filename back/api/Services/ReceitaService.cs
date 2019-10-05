using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace api.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitaRepository receitaRepository;

        public async Task<Receita> InserirReceitaAsync(Receita receita)
        {
            await receitaRepository.InsertAsync(receita);
            return receita;
        }

        public async Task<IEnumerable<Receita>> BuscarReceitaAsync()
        {
            var Receitas = await receitaRepository.FindAllAsync();
            return Receitas;
        }

        public async Task<IEnumerable<Receita>> pesquisarReceitaAsync(string nomeReceita)
        {
            var Receitas = await receitaRepository.pesquisarReceitaAsync(nomeReceita);
            return Receitas;
        }

        public async Task<Receita> BuscarReceitaAsync(int id)
        {
            var Receita = await receitaRepository.FindOneAsync(new Receita() { Id = id });
            return Receita;
        }

        public async Task<Receita> AtualizarReceitaAsync(Receita Receita)
        {
            await receitaRepository.UpdateAsync(Receita);
            return Receita;
        }

        public async Task ExcluirReceitaAsync(Receita receita)
        {
            await receitaRepository.DeleteAsync(receita);
        }

        
    }

}
