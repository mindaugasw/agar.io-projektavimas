using agar_client.Game;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using Xunit;
using System.Text.Json;
using System.Text.Json.Serialization;

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
			var p =
				new Utils.Point(1, 1)
				+ new Utils.Point(5, 9)
				- new Utils.Point(-11, 30)
				* new Utils.Point(5, 6) // Member-wise multiplication // NOTE: multiplication comes before division
				; // = 61, -170

			Assert.Equal(61, p.X);
			Assert.Equal(-170, p.Y);

			TestsHelper.LogModule("UtilsTests", p);
			p = p * 7   // scalar multiplication
				/ 2		// scalar division
				/ new Utils.Point(3, 5) // member-wise division
				; // = 71, -17

			Assert.Equal(71, p.X);
			Assert.Equal(-119, p.Y);
		}

		[StaFact]
		public void PointTypeCastingTest()
		{
			var p = new Utils.Point(15, 200);

			Assert.Equal(15, ((System.Windows.Point)p).X);
			Assert.Equal(15, ((System.Drawing.Point)p).X);

			var pWindows = new System.Windows.Point(16, 201);
			var pDrawing = new System.Drawing.Point(17, 202);

			Assert.Equal(16, ((Utils.Point)pWindows).X);
			Assert.Equal(17, ((Utils.Point)pDrawing).X);
		}

		[StaFact]
		public void PointEqualityTest()
		{
			var p1 = new Utils.Point(11, 51);
			var p2 = new Utils.Point(11, 51);

			Assert.Equal(p1, p2);
			Assert.NotSame(p1, p2);
		}

		[StaFact]
		public void JsonificationTest()
		{
			var p1 = new Utils.Point(22, 44);
			var p1Json = System.Text.Json.JsonSerializer.Serialize(p1);

			Assert.Equal(@"{""x"":22,""y"":44}", p1Json);

			var p2Json = @"{ ""x"": 33, ""y"": 55 }";
			var p2 = System.Text.Json.JsonSerializer.Deserialize<Utils.Point>(p2Json);

			Assert.Equal(33, p2.X);
			Assert.Equal(55, p2.Y);
		}
	}
}
