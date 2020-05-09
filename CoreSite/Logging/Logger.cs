using CoreSite.Base;
using NLog;

namespace CoreSite.Logging
{
	public class Logger : BaseBusiness, ILogger
	{
		private NLog.Logger logger = LogManager.GetCurrentClassLogger();

		public void Error<T>(T error) where T : class
		{
			logger.Error(error);
		}
	}
}