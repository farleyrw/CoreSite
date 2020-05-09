using CoreSite.Base;

namespace CoreSite.Services
{
	public class SomethingService : BaseBusiness, ISomethingService
	{
		public string GetSomething()
		{
			return "guh";
		}
    }
}