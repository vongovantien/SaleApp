using WebAPI.IServices;
using WebAPI.Utils;

namespace WebAPI.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, JwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = "";
            //if (userId != null)
            //{
            //    // attach user to context on successful jwt validation
            //    context.Items["User"] = userService.GetUserByIDAsync(userId.Value);
            //}

            await _next(context);
        }
    }
}
