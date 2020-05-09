using System;
using System.Collections.Generic;
using System.Text;
using CoreSite.Base;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreSite.Tests.Base
{
	[TestClass]
	public class BaseContextHelperTests
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

			var properties = A.Fake<PropertyValues>(options => options.CallsBaseMethods());

			properties.SetValues(model);

			var result = BaseContextHelper.BuildOriginalValues(model.GetType(), properties);

			result.Should().BeEquivalentTo(new Dictionary<string, object>
			{
				{ "Id", 123 },
				{ "IsActive", true },
				{ "Name", "test" }
			});
		}
	}
}
