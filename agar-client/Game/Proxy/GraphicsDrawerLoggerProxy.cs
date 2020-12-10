using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace agar_client.Game.Proxy
{
	class GraphicsDrawerLoggerProxy : IGraphicsDrawer
	{
		GraphicsDrawer igd; // Internal GraphicsDrawer

		string logFile = @"graphics_drawer_log.txt";

		public Canvas GameCanvas 
		{
			get { return igd.GameCanvas; }
			set { igd.GameCanvas = value; }
		}

		public GraphicsDrawerLoggerProxy()
		{
			Log("Creating Graphics drawer proxy");
			igd = new GraphicsDrawer();
			GraphicsDrawer.Instance = this;
		}

		public void AddControl(UIElement control, Utils.Point position)
		{
			Log($"Adding control; {control},{position}");
			igd.AddControl(control, position);
		}

		public Ellipse CreateNewEllipse(int size, Color color, Utils.Point position)
		{
			Log($"Creating new ellipse; {size},{color},{position}");
			return igd.CreateNewEllipse(size, color, position);
		}

		public Rectangle CreateNewRectangle(int size, Color color, Utils.Point position)
		{
			Log($"Creating new rectangle; {size},{color},{position}");
			return igd.CreateNewRectangle(size, color, position);
		}

		public Polygon CreateNewVirus(int size, Color color, Utils.Point position)
		{
			Log($"Creating new virus; {size},{color},{position}");
			return igd.CreateNewVirus(size, color, position);
		}

		public void MoveShape(Shape shape, Utils.Point position)
		{
			Log($"Moving shape; {shape},{position}");
			igd.MoveShape(shape, position);
		}

		public void RemoveShape(Shape shape)
		{
			Log($"Removing shape; {shape}");
			RemoveShape(shape);
		}

		void Log(object obj)
		{
			Logger.LogToFile(logFile, obj);
		}
	}
}
