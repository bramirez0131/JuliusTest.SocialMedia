using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JuliusTest.SocialMedia.Api.Filters
{
	/// <summary>
	/// Class ValidatorActionFilter.
	/// Implements the <see cref="IActionFilter" />
	/// Implements the <see cref="IAsyncActionFilter" />
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.Filters.IActionFilter" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IActionFilter" />
	/// <seealso cref="IAsyncActionFilter" />
	/// <seealso cref="IActionFilter" />
	public class ValidatorActionFilter : IActionFilter
	{
		/// <summary>
		/// Called before the action executes, after model binding is complete.
		/// </summary>
		/// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
		public void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.ModelState.IsValid)
			{
				context.Result = new BadRequestObjectResult(context.ModelState);
			}
		}

		/// <summary>
		/// Called after the action executes, before the action result.
		/// </summary>
		/// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext" />.</param>
		public void OnActionExecuted(ActionExecutedContext context)
		{
			if (!context.ModelState.IsValid)
			{
				context.Result = new BadRequestObjectResult(context.ModelState);
			}
		}
	}
}
