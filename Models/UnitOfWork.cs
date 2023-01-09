using Models.Repository.Implementation;
using Models.Repository.Interface;

namespace Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string ConnectionString;
        #region Register
        private IUsersRepository _UsersRepository;
        public IUsersRepository UsersRepository => _UsersRepository ?? (_UsersRepository = new UsersRepository(ConnectionString));
        #endregion
        public UnitOfWork(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
