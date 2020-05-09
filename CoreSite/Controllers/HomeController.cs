using CoreSite.Config;
using CoreSite.Logging;
using CoreSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CoreSite.Controllers
{
	public class HomeController : Controller
    {
		private ISomethingService service;
		private ILogger logger;
		private Parent parent;

		public HomeController(ISomethingService service, ILogger logger, IOptions<Parent> parent)
		{
			this.service = service;
			this.logger = logger;
			this.parent = parent.Value;
		}

        public IActionResult Index()
        {
            return View();
        }

		public object Settings()
		{
			return this.parent;
		}

        public IActionResult About()
        {
			ViewData["Message"] = this.service.GetSomething();
			this.logger.Error("guh");
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}