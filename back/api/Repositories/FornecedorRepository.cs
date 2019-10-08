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
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
        public async Task<IEnumerable<Fornecedor>> pesquisarFornecedorAsync(string nomeFornecedor)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                var sql = FornecedorScripts.BuscarFornecedorScript;
                var retorno = await conexao.QueryAsync<Fornecedor>(sql, nomeFornecedor);
                return retorno;
            }
        }
    }
}
