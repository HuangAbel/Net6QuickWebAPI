using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly JwtHelper _jwt;
        private readonly ILogger<TokenController> _logger;
        public TokenController(
          IMapper mapper,
          JwtHelper jwt,
          ILogger<TokenController> logger)
        {
            _mapper = mapper;
            _jwt = jwt;
            _logger = logger;
        }

        [HttpPost, Route("Login")]
        public IActionResult Login(Users users)
        {
            IResult<Users> result = new Result<Users>();
            if (ModelState.IsValid)
            {
                result.Data = new List<Users>() { new Users() { Token = _jwt.GenerateToken("testuser"), UserId = "testuser", UserName = "testuser" } };
                result.Success = true;
            }
            return new JsonResult(result);
        }
    }
}
