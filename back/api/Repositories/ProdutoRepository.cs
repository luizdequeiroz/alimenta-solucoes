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
       
    }
}
