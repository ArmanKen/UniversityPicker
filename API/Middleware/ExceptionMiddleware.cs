using System.Net;
using System.Text.Json;
using Application.Core;

namespace API.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionMiddleware> _logger;
		private readonly IHostEnvironment _env;
		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
		{
			_env = env;
			_logger = logger;
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				var response = _env.IsDevelopment() ?
					new AppException(context.Response.StatusCode, exception.Message, exception.StackTrace?.ToString()!) :
					new AppException(context.Response.StatusCode, "Server Error");
				var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
				var json = JsonSerializer.Serialize(response, options);
				await context.Response.WriteAsync(json);
			}
		}
	}
}