#pragma warning disable CS1591

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Boruc.LabEquip.Services.Equipment.API.Infrastructure.Filters
{
	using ActionResults;
	using Domain.Exceptions;

	public class HttpGlobalExceptionFilter : IExceptionFilter
	{
		private readonly IHostingEnvironment _environment;
		private readonly ILogger<HttpGlobalExceptionFilter> _logger;

		public HttpGlobalExceptionFilter(IHostingEnvironment environment, ILogger<HttpGlobalExceptionFilter> logger)
		{
			_environment = environment;
			_logger = logger;
		}

		public void OnException(ExceptionContext context)
		{
			_logger.LogError(new EventId(context.Exception.HResult), context.Exception, context.Exception.Message);

			if (context.Exception.GetType() == typeof(EquipmentDomainException))
			{
				var problemDetails = new ValidationProblemDetails
				{
					Instance = context.HttpContext.Request.Path,
					Status = StatusCodes.Status400BadRequest,
					Detail = "Please refer to the errors property for additional details.",
				};

				problemDetails.Errors.Add("DomainValidations", new[] { context.Exception.Message });

				context.Result = new BadRequestObjectResult(problemDetails);
				context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
			}
			else
			{
				var json = new JsonErrorResponse
				{
					Messages = new[] { "An error occur.Try it again." }
				};

				if (_environment.IsDevelopment())
				{
					json.DeveloperMessage = context.Exception;
				}

				context.Result = new InternalServerErrorObjectResult(json);
			}

			context.ExceptionHandled = true;
		}
	}

	public class JsonErrorResponse
	{
		public string[] Messages { get; set; }
		public object DeveloperMessage { get; set; }
	}
}
