using System.Data;
using api.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper.FastCrud;

namespace api.Repositories
{
    public sealed class ConnectionFactory : IConnectionFactory
    {
        private IConfiguration configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
            OrmConfiguration.DefaultDialect = SqlDialect.MySql;
        }
        
        public IDbConnection CreateConnectionOpened()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public string ConnectionString => configuration.GetConnectionString("MySqlConnectionString");
    }
}