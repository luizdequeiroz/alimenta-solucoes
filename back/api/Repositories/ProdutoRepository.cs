using api.Models;
using api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Repositories.Scripts;
using Dapper;

namespace api.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
        public async Task<IEnumerable<Produto>> pesquisarProdutosAsync(string nomeProduto)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                var sql = ProdutoScripts.BuscarProdutoScript;
                var retorno = await conexao.QueryAsync<Produto>(sql, nomeProduto);
                return retorno;
            }
        }
    }
}
