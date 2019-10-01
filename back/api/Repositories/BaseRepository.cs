using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Repositories.Interfaces;
using Dapper.FastCrud;

namespace api.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IConnectionFactory factory;

        public BaseRepository(IConnectionFactory connectionFactory)
        {
            this.factory = connectionFactory;
        }

        public bool Delete(TEntity entity)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                return conexao.Delete(entity);
            }
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                var transaction = conexao.BeginTransaction();
                try
                {
                    var retorno = await conexao.DeleteAsync(entity, statement => statement.AttachToTransaction(transaction));
                    transaction.Commit();
                    return retorno;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool Exists(TEntity entity)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                var funcionarioResult = conexao.Get(entity);

                return funcionarioResult != null;
            }
        }

        public async Task<bool> ExistsAsync(TEntity entity)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                var funcionarioResult = await conexao.GetAsync(entity);

                return funcionarioResult != null;
            }
        }

        public IEnumerable<TEntity> FindAll()
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                return conexao.Find<TEntity>();
            }
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                return await conexao.FindAsync<TEntity>();
            }
        }

        public TEntity FindOne(TEntity id)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                return conexao.Get(id);
            }
        }

        public async Task<TEntity> FindOneAsync(TEntity id)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                return await conexao.GetAsync(id);
            }
        }

        public void Insert(TEntity entity)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                var transaction = conexao.BeginTransaction();
                try
                {
                    conexao.Insert(entity, statement => statement.AttachToTransaction(transaction));
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task InsertAsync(TEntity entity)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                var transaction = conexao.BeginTransaction();
                try
                {
                    await conexao.InsertAsync(entity, statement => statement.AttachToTransaction(transaction));
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool Update(TEntity entity)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                var transaction = conexao.BeginTransaction();
                try
                {
                    var retorno = conexao.Update(entity, statement => statement.AttachToTransaction(transaction));
                    transaction.Commit();
                    return retorno;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            using (var conexao = factory.CreateConnectionOpened())
            {
                var transaction = conexao.BeginTransaction();
                try
                {
                    var updateResult = await conexao.UpdateAsync(entity, statement => statement.AttachToTransaction(transaction));
                    transaction.Commit();
                    return updateResult;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }   
    }
}