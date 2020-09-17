using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Text;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace agar_client
{
	class GraphicsDrawer
	{
		public static GraphicsDrawer Instance;
		Canvas GameCanvas;
		Shape Player;

		Point PlayerPosition;

		public GraphicsDrawer()
		{
			if (Instance == null)
				Instance = this;
			else
				throw new Exception();

			Player = GameManager.MainWindow.playerEllipse;
			GameCanvas = GameManager.MainWindow.gameCanvas;
			//PlayerPosition = GetPlayerPosition(); // Throws exception on main window
		}

		public void PlayerTranslate(Point translation)
		{
			if (PlayerPosition == null)
				PlayerPosition = GetPlayerPosition(); // Should be in constructor but throws up
			//Debug.WriteLine($"Starting pos: {PlayerPosition}");
			//Debug.WriteLine($"Translation: {translation}");

			PlayerPosition = PlayerPosition.Add(translation);
			//Debug.WriteLine($"Added: {PlayerPosition}");

			Canvas.SetLeft(Player, PlayerPosition.X);
			Canvas.SetTop(Player, PlayerPosition.Y);

			//Debug.WriteLine($"After set: {GetPlayerPosition()}");
		}

		public Point GetPlayerPosition()
		{
			Point relativeTo = new Point(0, 0);
			return Player.PointToScreen(relativeTo);
		}
		/*public void SetPlayerPosition(Point newPosition)
		{
			Canvas.SetLeft(Player, newPosition.X);
			Canvas.SetTop(Player, newPosition.Y);
			PlayerPosition = newPosition;
		}*/
	}
}
