using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Recipe.Api.ActionFilter
{
    public class RoleFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string userRole = GetUserIdFromJwt(context.HttpContext.Request.Headers["Authorization"]);

            if (!userRole.Equals("Admin"))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            base.OnActionExecuted(context);
        }

        private string GetUserIdFromJwt(string authorizationHeader)
        {
            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jsonToken != null)
                {
                    var role = jsonToken.Payload["Role"];
                    return role.ToString();
                }
            }

            return "";
        }
    }
}
