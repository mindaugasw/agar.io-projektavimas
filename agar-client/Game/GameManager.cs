using agar_client.Game;
using agar_client.Game.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace agar_client
{
	class GameManager
	{
		public static GameManager Instance;
		public static MainWindow MainWindow;

		public static Random Random;

		LocalPlayer LocalPlayer;

		public GameManager(MainWindow mainWindow)
		{
			if (Instance == null)
				Instance = this;
			else
				throw new Exception();

			MainWindow = mainWindow;

			Random = new Random();

			new CommunicationManager();
			new InputHandler();
			new GraphicsDrawer();

			Logger.Log("All services initialized");

			LocalPlayer = new LocalPlayer();

		}
	}
}
