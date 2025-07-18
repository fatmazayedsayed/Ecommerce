﻿using Ecommerce.API.Helper;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Text.Json;

namespace Ecommerce.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        private readonly IMemoryCache _memoryCache;
        private readonly TimeSpan _rateLimtWindow = TimeSpan.FromSeconds(30);
        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment environment, IMemoryCache memoryCache)
        {
            _next = next;
            _environment = environment;
            _memoryCache = memoryCache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                ApplySecurity(context);
                if (IsRequestAllowed(context) == false)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    context.Response.ContentType = "application/json";
                    var response = new ApiExceptions((int)HttpStatusCode.TooManyRequests, "Too Many Request Attemps, please try again later");
                    await context.Response.WriteAsJsonAsync(response);

                }
                await _next(context);
            }
            catch (Exception ex)
            {

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var response = _environment.IsDevelopment() ? new ApiExceptions((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace) : new ApiExceptions((int)HttpStatusCode.InternalServerError, ex.Message);
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
        //Who is send request
        private bool IsRequestAllowed(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress.ToString();
            var cashKey = $"Rate: {ip}";
            var dateNow = DateTime.Now;
            var (timestamp, count) = _memoryCache.GetOrCreate(cashKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = _rateLimtWindow;
                return (timestamp: dateNow, count: 0);
            });
            if (dateNow - timestamp < _rateLimtWindow)
            {
                if (count >= 8)// after 8 attempts in 30 seconds, block the request
                {
                    return false;
                }
                _memoryCache.Set(cashKey, (timestamp, count += 1), _rateLimtWindow);
            }
            else
            {
                _memoryCache.Set(cashKey, (timestamp, count), _rateLimtWindow);
            }
            return true;
        }

        private void ApplySecurity(HttpContext context)
        {
            context.Response.Headers["X-Content-Type-Options"] = "nosniff";
            context.Response.Headers["X-XSS-Protection"] = "1;mode=block";
            context.Response.Headers["X-Frame-Options"] = "DENY";
        }

    }

}
