using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private readonly Stopwatch _timer;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _timer.Start();
            await next.Invoke(context);
            _timer.Stop();
            TimeSpan timeTaken = _timer.Elapsed;
            if (timeTaken.Seconds > 4)
            {
                var message = $"Request [{context.Request.Method}] at {context.Request.Path} took: {timeTaken.ToString(@"m\:ss\.fff")} m";
                _logger.LogInformation(message);
            }

        }
    }
}