using System;
using Xunit;
using agar_client;
using agar_client.Game;
using System.Diagnostics;

namespace agar_client.Tests
{
	public class MainTests : IDisposable
	{
		public MainTests()
		{
			TestsHelper.LogModule("MainTests", "CTOR");
			TestsHelper.InitializeServices();
		}

		public void Dispose()
		{
			TestsHelper.DisposeServices();
		}


		[StaFact]
		public void CheckServicesSingleton()
		{
			TestsHelper.LogModule("MainTests", "CheckServicesSingleton");
			Assert.NotNull(TestsHelper.mw);
			Assert.NotNull(TestsHelper.gm);
			Assert.NotNull(TestsHelper.ih);
			Assert.NotNull(TestsHelper.gd);
			Assert.NotNull(TestsHelper.cm);
		}
	}
}
