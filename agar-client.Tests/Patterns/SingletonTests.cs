using System;
using Xunit;
using agar_client;
using agar_client.Game;
using System.Diagnostics;

namespace agar_client.Tests.Patterns
{
	public class SingletonTests : IDisposable
	{
		public SingletonTests()
		{
			TestsHelper.LogModule("SingletonTests", "CTOR");
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
			Assert.NotNull(MainWindow.Instance);
			Assert.NotNull(GameManager.Instance);
			Assert.NotNull(InputHandler.Instance);
			Assert.NotNull(GraphicsDrawer.Instance);
			Assert.NotNull(CommunicationManager.Instance);
		}
	}
}
