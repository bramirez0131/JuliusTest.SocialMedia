using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Net;

namespace JuliusTest.SocialMedia.Api.Filters
{
	/// <summary>
	/// Class GlobalExceptionFilter.
	/// Implements the <see cref="IExceptionFilter" />
	/// </summary>
	/// <seealso cref="IExceptionFilter" />
	public class GlobalExceptionFilter : IExceptionFilter
	{
		/// <summary>
		/// Called after an action has thrown an <see cref="T:System.Exception" />.
		/// </summary>
		/// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext" />.</param>
		public void OnException(ExceptionContext context)
		{
			var exception = context.Exception;
			var validation = new
			{
				Status = 500,
				Title = "Error",
				Detail = exception.Message
			};

			var json = new
			{
				errors = new[] { validation }
			};

			context.Result = new BadRequestObjectResult(json);
			context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
			context.ExceptionHandled = true;
		}
	}
}
