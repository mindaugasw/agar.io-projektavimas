using agar_client.Game;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace agar_client.Tests
{
	public class UtilsTests : IDisposable
    {
		public UtilsTests()
		{
			TestsHelper.LogModule("UtilsTests", "CTOR");
			TestsHelper.InitializeServices();
		}

		public void Dispose()
		{
			TestsHelper.DisposeServices();
		}

		[StaFact]
		public void RandomStringTest()
		{
			TestsHelper.LogModule("UtilsTests", "RandomStringTest");
			var s1 = Utils.RandomString(16);
			var s2 = Utils.RandomString(16);

			Assert.Equal(16, s1.Length);
			Assert.NotEqual(s1, s2);
		}

		[StaFact]
		public void PointMathTest()
		{
			// TODO

			Assert.True(false);
		}

		[StaFact]
		public void PointConversionTest()
		{
			// TODO

			Assert.True(false);
		}

		[StaFact]
		public void PointEqualityTest()
		{
			// TODO

			Assert.True(false);
		}
	}
}
