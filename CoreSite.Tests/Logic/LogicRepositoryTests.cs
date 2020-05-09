using System;
using System.Threading.Tasks;
using CoreSite.Logic;
using CoreSite.Logic.Interfaces;
using CoreSite.Logic.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreSite.Tests.Logic
{
	[TestClass]
	public class LogicRepositoryTests
	{
		private LogicRepository underTest;
		private ILogicContext logicContext;

		private DbContextOptions<LogicContext> dbOptions;

		public LogicRepositoryTests()
		{
			this.dbOptions = new DbContextOptionsBuilder<LogicContext>()
				.UseInMemoryDatabase("test shit")
				.Options;
		}

		[TestInitialize]
		public void Setup()
		{
			this.Init();
		}

		public void Init()
		{
			this.logicContext = new LogicContext(this.dbOptions);
			
			this.underTest = new LogicRepository(this.logicContext);
		}

		[TestMethod]
		public async Task GetStuffs()
		{
			this.logicContext.Stuffs.AddRange(new Stuff { Id = Guid.NewGuid(), Name = "guh" }, new Stuff { Id = Guid.NewGuid(), Name = "bootstrap" });

			await this.logicContext.SaveChangesAsync();

			this.Init(); // To ensure data stays in in memory between context instances

			var result = this.underTest.GetThings();

			result.Count.Should().Be(2);
		}
	}
}