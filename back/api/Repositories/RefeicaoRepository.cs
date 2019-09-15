using api.Models;
using api.Models.Enums;
using api.Repositories.Interfaces;
using api.Repositories.Scripts;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class RefeicaoRepository : IRefeicaoRepository
    {
        private readonly MySqlConnection connection;

        public RefeicaoRepository(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<Refeicao>> SelectByClientIdAndPeriodAsync(int clienteId, DateTime dataInicial, DateTime dataFinal)
        {
            return await connection.QueryAsync<Refeicao>(RefeicaoScripts.SELECT_BY_CLIENT_AND_PERIOD, new { @clienteId, @dataInicial, @dataFinal });
        }

        public async Task<IEnumerable<Refeicao>> SelectByClientIdPeriodAndTypeAsync(int clienteId, DateTime dataInicial, DateTime dataFinal, TipoRefeicao tipoRefeicao)
        {
            return await connection.QueryAsync<Refeicao>(RefeicaoScripts.SELECT_BY_CLIENT_PERIOD_AND_TYPE, new { @clienteId, @dataInicial, @dataFinal, @tipoRefeicao });
        }
    }
}
