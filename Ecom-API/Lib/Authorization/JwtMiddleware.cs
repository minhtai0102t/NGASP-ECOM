using System;
using Ecom_API.Service.Interfaces;
namespace Ecom_API.Authorization
{
	public class JwtMiddleware
	{
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = (Guid)jwtUtils.ValidateToken(token);
            if (userId != Guid.Empty)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetById(userId);
            }

            await _next(context);
        }
    }
}

