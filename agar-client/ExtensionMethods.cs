using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace agar_client
{
	static class ExtensionMethods
	{
		public static Point Multiply(this Point point, int multiplier)
		{
			return new Point(point.X * multiplier, point.Y * multiplier);
		}
		public static Point Add(this Point thisPoint, Point point)
		{
			return new Point(thisPoint.X + point.X, thisPoint.Y + point.Y);
		}

	}
}
