using CoreSite.Base;
using CoreSite.Logic.Interfaces;
using CoreSite.Logic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreSite.Logic
{
	public class LogicContext : BaseContext, ILogicContext
    {
		public LogicContext(IConfiguration config) : base(config.GetConnectionString("HF")) { }

		public LogicContext(DbContextOptions<LogicContext> options) : base(options) { }

		public DbSet<Stuff> Stuffs { get; set; }
	}
}