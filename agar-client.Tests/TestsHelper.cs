using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using agar_client;
using agar_client.Game;

namespace agar_client.Tests
{
    static class TestsHelper
    {
        static bool initialized = false;

		public static MainWindow mw;
		public static GameManager gm;
		public static InputHandler ih;
		public static GraphicsDrawer gd;
		public static CommunicationManager cm;

		static StreamWriter logFile;
		// Set to true to enable logging to file (unstable)
		static bool loggingEnabled = false;

		public static void InitializeServices()
		{
			loggingEnabled = ConfigManager.Get<bool>("testsLoggingEnabled");

			LogModule("TestHelper", "InitializeServices");
			if (initialized)
			{
				LogModule("TestHelper", "Already initialized, cancelling");
				return;
			}


			if (MainWindow.Instance == null)
			{
				mw = new MainWindow();
				LogModule("TestHelper", "MainWindow created");
			}
			else
				mw = MainWindow.Instance;

			if (GameManager.Instance == null)
			{
				gm = new GameManager(true);
				LogModule("TestHelper", "GameManaer created");
				LogModule("TestHelper", "GameManager env: "+GameManager.IsTestEnvironment.ToString());
			}
			else
				gm = GameManager.Instance;

			ih = InputHandler.Instance;
			gd = GraphicsDrawer.Instance;
			cm = CommunicationManager.Instance;

			initialized = true;
		}

		public static void DisposeServices()
		{
			if (loggingEnabled && logFile != null)
			{
				logFile.Close();
				logFile = null;
			}

			//if (mw != null)
			//	mw.Close();

			//MainWindow.Instance.Dispatcher.Invoke(() => { // Hangs up second test
				//MainWindow.Instance.Close();
				//Environment.Exit(0);
				
			//});

		}

		// Log with timestamp and module name included
		public static void LogModule(string module, object content)
		{
			LogTime($"{module}: {content.ToString()}");
		}
		
		// Log with timestamp included
		public static void LogTime(object content)
		{
			Log($"\n{DateTime.Now.ToString("HH:mm:ss")}: {content.ToString()}");
		}

		// Log to console and to file, is flag is set to true
		public static void Log(object content)
		{
			Debug.Write(content);
			if (loggingEnabled)
			{
				if (logFile == null)
					logFile = new StreamWriter("../../../../log.client.tests.txt", true);

				logFile.Write(content);
			}
		}
	}
}
