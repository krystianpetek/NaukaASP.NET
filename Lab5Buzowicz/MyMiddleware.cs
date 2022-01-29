using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Lab5Buzowicz
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}
