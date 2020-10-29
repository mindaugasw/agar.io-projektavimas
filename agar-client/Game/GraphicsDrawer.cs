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

		public GraphicsDrawer()
		{
			if (Instance == null)
				Instance = this;
			else
				throw new Exception();

			GameCanvas = MainWindow.Instance.gameCanvas;
		}



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

		public static Polygon CreateNewVirus(int size, System.Windows.Media.Color color, Utils.Point position)
		{
			PointCollection p = new PointCollection();
			p.Add(new System.Windows.Point(0, 25));
			p.Add(new System.Windows.Point(20, 20));
			p.Add(new System.Windows.Point(25, 0));
			p.Add(new System.Windows.Point(30, 20));
			p.Add(new System.Windows.Point(50, 25));
			p.Add(new System.Windows.Point(30, 30));
			p.Add(new System.Windows.Point(25, 50));
			p.Add(new System.Windows.Point(20, 30));
			Polygon e = new Polygon() { Points = p };
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
			return shape.PointToScreen(relativeTo); // TODO. Not working, returns wrong position
		}*/

		public static void RemoveShape(Shape shape) {
			Instance.GameCanvas.Children.Remove(shape);
		}
	}
}
