using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BillingApp.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogError(ex, "Divide by zero exception occurred.");
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsJsonAsync(new { statusCode = httpContext.Response.StatusCode, message = "Division by zero is not allowed." });
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "Null reference exception occurred.");
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsJsonAsync(new { statusCode = httpContext.Response.StatusCode, message = "A null reference occurred. Please ensure all objects are initialized properly." });
            }
            catch (ArithmeticException ex)
            {
                _logger.LogError(ex, "Arithmetic exception occurred.");
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsJsonAsync(new { statusCode = httpContext.Response.StatusCode, message = "An arithmetic operation error occurred." });
            }
            //Add More types of Exception here
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An unexpected error occurred.");
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsJsonAsync(new { statusCode = httpContext.Response.StatusCode, message = "An unexpected error occurred.", details = ex.Message });
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
