using System.Data;

namespace api.Repositories.Interfaces
{
    public interface IConnectionFactory
    {
         IDbConnection CreateConnectionOpened();
    }
}