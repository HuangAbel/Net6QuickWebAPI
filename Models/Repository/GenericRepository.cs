using Dapper;
using Models.Extensions;
using System.Data;
using System.Data.SqlClient;

namespace Models
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected string ConnectionString { get; }
        public GenericRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<IEnumerable<TEntity>> Select(TEntity entity)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                ShareMethod.SetExecuteType(entity);
                return await con.QueryAsync<TEntity>(
                    entity.GetType().Name,
                    entity.GetInputProperties(),
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public async Task<IEnumerable<TEntity>> Insert(TEntity entity)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                ShareMethod.SetExecuteType(entity);
                return await con.QueryAsync<TEntity>(
                    entity.GetType().Name,
                    entity.GetInputProperties(),
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public async Task<IEnumerable<TEntity>> Delete(TEntity entity)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                ShareMethod.SetExecuteType(entity);
                return await con.QueryAsync<TEntity>(
                    entity.GetType().Name,
                    entity.GetInputProperties(),
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public async Task<IEnumerable<TEntity>> Update(TEntity entity)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                ShareMethod.SetExecuteType(entity);
                return await con.QueryAsync<TEntity>(
                    entity.GetType().Name,
                    entity.GetInputProperties(),
                    commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
