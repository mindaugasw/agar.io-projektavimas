using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Media;
using System.Windows;
using agar_client.Game;

namespace agar_client
{
	class GraphicsDrawer
	{
		public static GraphicsDrawer Instance;
		Canvas GameCanvas;
		//Shape Player;

		//System.Windows.Point PlayerPosition;

		public GraphicsDrawer()
		{
			if (Instance == null)
				Instance = this;
			else
				throw new Exception();

			//Player = GameManager.MainWindow.playerEllipse;
			GameCanvas = GameManager.MainWindow.gameCanvas;
			//PlayerPosition = GetPlayerPosition(); // Throws exception on main window
		}

		/*public void PlayerTranslate(System.Windows.Point translation)
		{
			*if (PlayerPosition == null)
				PlayerPosition = GetPlayerPosition(); // Should be in constructor but throws up*

			//Debug.WriteLine($"Starting pos: {PlayerPosition}");
			//Debug.WriteLine($"Translation: {translation}");

			//PlayerPosition = PlayerPosition.Add(translation);
			//Debug.WriteLine($"Added: {PlayerPosition}");

			//Canvas.SetLeft(Player, PlayerPosition.X);
			//Canvas.SetTop(Player, PlayerPosition.Y);

			//Debug.WriteLine($"After set: {GetPlayerPosition()}");
		}*/

		/*public Point GetPlayerPosition()
		{
			Point relativeTo = new Point(0, 0);
			return Player.PointToScreen(relativeTo);
		}*/
		/*public void SetPlayerPosition(Point newPosition)
		{
			Canvas.SetLeft(Player, newPosition.X);
			Canvas.SetTop(Player, newPosition.Y);
			PlayerPosition = newPosition;
		}*/



		public static Ellipse CreateNewEllipse(int size, System.Windows.Media.Color color, Utils.Point position)
		{
			Ellipse e = new Ellipse();
			Instance.GameCanvas.Children.Add(e);
			e.Width = size;
			e.Height = size;
			e.Fill = new SolidColorBrush(color);
			e.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
			e.StrokeThickness = 2;
			MoveShape(e, position);
			return e;
		}

		/// <summary>
		/// Move shape to specific absolute position
		/// </summary>
		public static void MoveShape(Shape shape, Utils.Point position)
		{
			Canvas.SetLeft(shape, position.X);
			Canvas.SetTop(shape, position.Y);
		}

		/// summary>
		/// Move shape relatively to its current position
		/// </summary>
		/*public static void TranslateShape(Shape shape, Utils.Point translation)
		{
			MoveShape(shape, GetShapePosition(shape) + translation);
			//throw new NotImplementedException();
		}
		public static Utils.Point GetShapePosition(Shape shape)
		{
			Utils.Point relativeTo = new Utils.Point();
			return shape.PointToScreen(relativeTo); // TODO. Not working / working weirdly
		}*/
	}
}
