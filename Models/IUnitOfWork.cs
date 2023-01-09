using Models.Repository.Interface;

namespace Models
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository UsersRepository { get; }
    }
}
