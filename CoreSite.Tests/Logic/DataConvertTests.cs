using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreSite.Tests.Logic
{
	[TestClass]
	public class DataConvertTests
	{
		[TestMethod]
		public void ConvertGuid()
		{
			string value = "0e86fec0-14d8-4c99-a152-22e3743438e0";
			//object y = Convert.ChangeType(value, typeof(Guid));

			object y = TypeDescriptor.GetConverter(typeof(Guid)).ConvertFromInvariantString(value);

			Assert.AreEqual(value, ((Guid)y).ToString());
		}

		[TestMethod]
		public void ConvertDatetime()
		{
			string value = "2015-03-29T22:50:53.053";

			//object y = Convert.ChangeType(value, typeof(DateTime));

			object y = TypeDescriptor.GetConverter(typeof(DateTime)).ConvertFromInvariantString(value);

			Assert.AreEqual(value, ((DateTime)y).ToString("yyyy-MM-ddTHH:mm:ss.fff"));
		}
	}
}