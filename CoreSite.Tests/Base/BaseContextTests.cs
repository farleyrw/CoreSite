using System.Collections.Generic;
using CoreSite.Base;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreSite.Tests.Base
{
	[TestClass]
	public class BaseContextTests
	{
		[TestMethod]
		public void BuildOriginalValues()
		{
			var model = new TestModel
			{
				Id = 123,
				IsActive = true,
				Name = "test"
			};
		}
	}

	public class TestContext : BaseContext
	{
		public TestContext(DbContextOptions options) : base(options) { }
		public DbSet<TestModel> TestModels { get; set; }
	}

	public class TestModel : BaseEntity
	{
		public int Id { get; set; }
		public bool IsActive { get; set; }
		public string Name { get; set; }
	}
}
