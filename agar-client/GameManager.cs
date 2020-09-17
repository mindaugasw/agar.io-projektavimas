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

		public GameManager(MainWindow mainWindow)
		{
			if (Instance == null)
				Instance = this;
			else
				throw new Exception();

			MainWindow = mainWindow;

			new InputHandler();
			new GraphicsDrawer();
			new CommunicationManager();

			Debug.WriteLine("Starting");
		}

	}
}
