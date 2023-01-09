using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"];
            if (user == null  /*沒有登入使用者*/)
            {
                context.Result = new JsonResult(new { message = "驗證失敗" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
