using api.Models;
using api.Repositories.Interfaces;
using api.Repositories.Scripts;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly MySqlConnection connection;

        public ClienteRepository(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<Cliente>> SelectAllAsync()
        {
            return await connection.QueryAsync<Cliente>(ClienteScripts.SELECT_ALL);
        }
    }
}
