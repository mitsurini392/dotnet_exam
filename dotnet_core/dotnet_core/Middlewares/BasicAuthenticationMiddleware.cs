using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using dotnet_core.Model;

namespace dotnet_core.Middlewares
{
    public class BasicAuthenticationMiddleware
    {
        User user = new User();
        private readonly RequestDelegate _next;

        public BasicAuthenticationMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext) {
            string authHeader = httpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic")) {
                string ecodeEmailAndPassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                string emailAndPassword = encoding.GetString(Convert.FromBase64String(ecodeEmailAndPassword));
                int index = emailAndPassword.IndexOf(":");
                var email = emailAndPassword.Substring(0, index);
                var password = emailAndPassword.Substring(index + 1);

                if (email.Equals(user.emailAddress) && password.Equals(user.password)) {
                    await _next.Invoke(httpContext);
                }
                else {
                    httpContext.Response.StatusCode = 401;
                    return;
                }
            }
            httpContext.Response.StatusCode = 401;
            return;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BasicAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthenticationMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<BasicAuthenticationMiddleware>();
        }
    }
}
