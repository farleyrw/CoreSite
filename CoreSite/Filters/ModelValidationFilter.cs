using CoreSite.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreSite.Filters
{
	public class ModelValidationFilter : ActionFilterAttribute
	{
		private ILogger logger;

		public ModelValidationFilter(ILogger logger)
		{
			this.logger = logger;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.ModelState.IsValid)
			{
				this.logger.Error(context.ModelState);

				context.Result = new BadRequestObjectResult(context.ModelState);
			}
		}
	}
}
