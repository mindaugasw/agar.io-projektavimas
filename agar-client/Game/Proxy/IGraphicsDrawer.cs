using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace agar_client.Game.Proxy
{
	public interface IGraphicsDrawer
	{
		Canvas GameCanvas { get; set; }

		Ellipse CreateNewEllipse(int size, System.Windows.Media.Color color, Utils.Point position);

		Rectangle CreateNewRectangle(int size, System.Windows.Media.Color color, Utils.Point position);

		Polygon CreateNewVirus(int size, System.Windows.Media.Color color, Utils.Point position);
		
		void AddControl(UIElement control, Utils.Point position);

		void MoveShape(Shape shape, Utils.Point position);

		void RemoveShape(Shape shape);

	}
}
