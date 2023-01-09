using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Entity;
using Services.Interface;
using WebAPI.Extensions;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _usersService;
        public UsersController(
          IMapper mapper,
          ILogger<UsersController> logger,
          IUsersService usersService)
        {
            _mapper = mapper;
            _logger = logger;
            _usersService = usersService;
        }

        [HttpPost, Route("GetUser")]
        public IActionResult GetUser(Users users)
        {
            IResult<Users> result = new Result<Users>();
            if (ModelState.IsValid)
            {
                var mapUsers = this._mapper.Map<SP_Users>(users);
                result = this._mapper.Map<Result<Users>>(this._usersService.GetUsers(mapUsers).ErrorLog(this._logger).GetResult).GetIResult;
            }
            return new JsonResult(result);
        }
    }
}
