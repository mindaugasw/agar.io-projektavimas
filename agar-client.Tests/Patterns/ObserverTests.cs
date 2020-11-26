using System;
using Xunit;
using agar_client;
using agar_client.Game;
using agar_client.Game.Objects.Builder;
using agar_client.Game.Objects;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics;

namespace agar_client.Tests.Patterns
{
	public class ObserverTests : IDisposable
	{
		public ObserverTests()
		{
			TestsHelper.InitializeServices();
		}

		public void Dispose()
		{
			TestsHelper.DisposeServices();
		}

		[StaFact]
		public void ArrowKeysInputTest()
		{
			string result1 = null;
			string result2 = null;

			void localInputHandler1(string direction)
			{
				result1 = direction;
			}

			// Actual input handler removed, as player is not yet initialized
			MainWindow.Instance.ArrowKeysInput -= InputHandler.Instance.Player_move;

			MainWindow.Instance.ArrowKeysInput += dir => { result2 = dir; };
			MainWindow.Instance.ArrowKeysInput += localInputHandler1;

			MainWindow.Instance.InvokeArrowKeysEvent(this, "right");
			Assert.Equal("right", result1);
			Assert.Equal("right", result2);

			MainWindow.Instance.InvokeArrowKeysEvent(this, "down");
			Assert.Equal("down", result1);

			// result1 should not change anymore after removeing handler1
			MainWindow.Instance.ArrowKeysInput -= localInputHandler1;
			MainWindow.Instance.InvokeArrowKeysEvent(this, "up");
			Assert.Equal("down", result1);
		}
	}
}
