using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using Test_e.Server.Exceptions;

namespace Test_e.Server.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/problem+json";
                var problemDetails = CreateProblemDetails(context, ex);
                context.Response.StatusCode = problemDetails.Status ?? (int)HttpStatusCode.InternalServerError;

                var json = JsonSerializer.Serialize(problemDetails);
                await context.Response.WriteAsync(json);
            }
        }

        private ProblemDetails CreateProblemDetails(HttpContext context, Exception ex)
        {
            return ex switch
            {
                ArgumentNullException => new ProblemDetails
                {
                    Title = "Bad Request",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = ex.Message,
                    Instance = context.Request.Path
                },
                ArgumentException => new ProblemDetails
                {
                    Title = "Bad Request",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = ex.Message,
                    Instance = context.Request.Path
                },
                BadHttpRequestException => new ProblemDetails
                {
                    Title = "Bad Request",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = ex.Message,
                    Instance = context.Request.Path
                },
                NotFoundException => new ProblemDetails
                {
                    Title = "Not Found",
                    Status = StatusCodes.Status404NotFound,
                    Detail = ex.Message,
                    Instance = context.Request.Path
                },
                ConflictException => new ProblemDetails
                {
                    Title = "Conflict",
                    Status = StatusCodes.Status409Conflict,
                    Detail = ex.Message,
                    Instance = context.Request.Path
                },
                _ => new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = _env.IsDevelopment() ? ex.ToString() : "An unexpected error occurred.",
                    Instance = context.Request.Path
                }
            };
        }
    }
}