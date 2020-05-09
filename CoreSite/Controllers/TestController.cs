using System.Threading.Tasks;
using CoreSite.Logging;
using CoreSite.Logic.Interfaces;
using CoreSite.Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreSite.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TestController : Controller
    {
		private readonly ILogicRepository service;
		private readonly ILogger logger;

		public TestController(ILogicRepository service, ILogger logger)
		{
			this.service = service;
			this.logger = logger;
		}

		public IActionResult Index()
        {
			var x = this.service.GetThings();

            return Ok(x);
        }

		[HttpPost("in")]
		public async Task<IActionResult> Save(Stuff stuff)
		{
			this.service.ApplyChanges(stuff);

			//var count = await this.service.SaveChangesAsync();

			return Ok(stuff);
		}
    }
}