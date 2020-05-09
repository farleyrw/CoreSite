namespace CoreSite.Logging
{
	public interface ILogger
    {
		void Error<T>(T error) where T : class;
    }
}