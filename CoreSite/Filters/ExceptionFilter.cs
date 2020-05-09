using CoreSite.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreSite.Filters
{
	public class ExceptionFilter : ExceptionFilterAttribute
	{
		private ILogger logger;

		public ExceptionFilter(ILogger logger)
		{
			this.logger = logger;
		}

		public override void OnException(ExceptionContext context)
		{
			// TODO: should not log full exception when not in debug
			this.logger.Error(context.Exception);

			base.OnException(context);
		}
	}
}