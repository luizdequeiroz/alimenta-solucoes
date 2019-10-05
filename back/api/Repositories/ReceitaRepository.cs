using api.Models;
using api.Repositories.Interfaces;
using api.Repositories.Scripts;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class ReceitaRepository : BaseRepository<Receita>, IReceitaRepository
    {
        public ReceitaRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
        public async Task<IEnumerable<Receita>> pesquisarReceitaAsync(string nomeReceita)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                var sql = ReceitaScripts.BuscarReceitaScript;
                var retorno = await conexao.QueryAsync<Receita>(sql, nomeReceita);
                return retorno;
            }
        }
    }
}
