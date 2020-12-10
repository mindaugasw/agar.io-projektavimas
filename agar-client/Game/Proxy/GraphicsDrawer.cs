using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Media;
using agar_client.Game;
using System.Windows.Markup;
using agar_client.Game.Proxy;

namespace agar_client
{
	public class GraphicsDrawer : IGraphicsDrawer
	{
		//public static GraphicsDrawer Instance;
		public static IGraphicsDrawer Instance;

		static object lockObj = new object();

		public Canvas GameCanvas { get; set; }

		public GraphicsDrawer()
		{
			lock (lockObj)
			{
				if (Instance == null)
					Instance = this;
				else
					throw new Exception();
			}

			GameCanvas = MainWindow.Instance.gameCanvas;
		}


		public Ellipse CreateNewEllipse(int size, System.Windows.Media.Color color, Utils.Point position)
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

		public System.Windows.Shapes.Rectangle CreateNewRectangle(int size, System.Windows.Media.Color color, Utils.Point position)
		{
			System.Windows.Shapes.Rectangle r = new System.Windows.Shapes.Rectangle();
			Instance.GameCanvas.Children.Add(r);
			r.Width = size;
			r.Height = size;
			r.Fill = new SolidColorBrush(color);
			r.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
			r.StrokeThickness = 2;
			MoveShape(r, position);
			return r;
		}

		public void AddControl(UIElement control, Utils.Point position)
		{
			Instance.GameCanvas.Children.Add(control);
			Canvas.SetLeft(control, position.X);
			Canvas.SetTop(control, position.Y);
		}

		public Polygon CreateNewVirus(int size, System.Windows.Media.Color color, Utils.Point position)
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
		public void MoveShape(Shape shape, Utils.Point position)
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

		public void RemoveShape(Shape shape) {
			Instance.GameCanvas.Children.Remove(shape);
		}
	}
}
