using Models.Entity;
using Models.Repository.Interface;

namespace Models.Repository.Implementation
{
    internal class UsersRepository : GenericRepository<SP_Users>, IUsersRepository
    {
        public UsersRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
