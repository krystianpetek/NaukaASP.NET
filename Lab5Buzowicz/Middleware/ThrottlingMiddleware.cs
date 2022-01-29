using Lab5Buzowicz.Services;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lab5Buzowicz.Middleware
{
    public class ThrottlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMetricsCollector _collector;
        public ThrottlingMiddleware(RequestDelegate next, IMetricsCollector collector)
        {
            _collector = collector;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            await _next(context);
            Stopwatch stopwatch = Stopwatch.StartNew();
            var requestMethod = context.Request.Method;
            var requestPath = context.Request.Path;
            var responseStatusCode = context.Response.StatusCode;
            if(stopwatch.Elapsed.Seconds > 10)
            {
                stopwatch.Restart();
            }
            _collector.Record(requestMethod, requestPath, responseStatusCode, stopwatch);

            // nie umiem
        }
    }
}
