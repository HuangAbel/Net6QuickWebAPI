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
        private readonly ValidateCodeHelper _validateCodeHelper;
        public TokenController(
          IMapper mapper,
          JwtHelper jwt,
          ILogger<TokenController> logger,
          ValidateCodeHelper validateCodeHelper)
        {
            _mapper = mapper;
            _jwt = jwt;
            _logger = logger;
            _validateCodeHelper = validateCodeHelper;
        }

        [HttpPost, Route("Login")]
        public IActionResult Login(Users users)
        {
            IResult<Users> result = new Result<Users>();
            if (ModelState.IsValid)
            {
                string vc = HttpContext.Session.GetString(_validateCodeHelper.captachaCodeName) ?? "";
                result.Data = new List<Users>() { new Users() { Token = _jwt.GenerateToken("testuser"), UserId = "testuser", UserName = "testuser" } };
                result.Success = true;
            }
            return new JsonResult(result);
        }
        [HttpPost, Route("ValidateCode")]
        public IActionResult ValidateCode()
        {
            string code = _validateCodeHelper.CreateValidateCode(5);
            HttpContext.Session.SetString(_validateCodeHelper.captachaCodeName, code);
            byte[] imgByte = _validateCodeHelper.CreateValidateGraphic(code);
            return File(imgByte, @"image/jpeg");
        }
    }
}
