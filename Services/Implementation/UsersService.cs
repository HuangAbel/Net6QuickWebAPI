using Models;
using Models.Entity;
using Services.Interface;

namespace Services.Implementation
{
    public class UsersService : IUsersService
    {
        private IUnitOfWork _unitOfWork;
        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IResult<SP_Users> GetUsers(SP_Users para)
        {
            IResult<SP_Users> result = new Result<SP_Users>();
            try
            {
                result.Data = this._unitOfWork.UsersRepository.Select(para).Result;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }
    }
}
