using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ProductMicroService.Utilities.MiddleWares;

public class ExceptionHandlingMiddleware
{
	private readonly RequestDelegate next;
	private readonly ILogger<ExceptionHandlingMiddleware> logger;

	public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
	{
		this.next = next;
		this.logger = logger;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Unhandled Exception");
			context.Response.StatusCode = 500;
			context.Response.ContentType = "application/json";

			var response = new
			{
				message = "An unexpexted error occured",
				details = ex.Message
			};

			await context.Response.WriteAsync(JsonSerializer.Serialize(response));
		}
	}
}

