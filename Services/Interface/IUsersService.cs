using Models;
using Models.Entity;

namespace Services.Interface
{
    public interface IUsersService
    {
        IResult<SP_Users> GetUsers(SP_Users para);
    }
}
