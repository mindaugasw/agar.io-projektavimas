using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace agar_client.Game
{
	static class Utils
	{
		public static string RandomString(int length)
		{
			const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[GameManager.Random.Next(s.Length)]).ToArray());
		}

		/// <summary>
		/// 2D Point structure that allows easy conversion between System.Windows.Point and System.Drawing.Point
		/// </summary>
		public struct Point
		{
			[JsonPropertyName("x")]
			public int X { get; set; }
			[JsonPropertyName("y")]
			public int Y { get; set; }

			public Point(int x = 0, int y = 0)
			{
				X = x;
				Y = y;
			}


			// --- CONVERSIONS ---

			public static implicit operator System.Windows.Point(Point p)
			{
				return new System.Windows.Point(p.X, p.Y);
			}
			public static implicit operator System.Drawing.Point(Point p)
			{
				return new System.Drawing.Point(p.X, p.Y);
			}
			public static implicit operator Point(System.Windows.Point p)
			{
				return new Point((int)p.X, (int)p.Y);
			}
			public static implicit operator Point(System.Drawing.Point p)
			{
				return new Point(p.X, p.Y);
			}


			// --- MATH OPERATORS ---

			public static Point operator +(Point a, Point b)
			{
				return new Point(a.X + b.X, a.Y + b.Y);
			}
			public static Point operator -(Point a, Point b)
			{
				return new Point(a.X - b.X, a.Y - b.Y);
			}
			/// <summary>
			/// Member-wise multiplication
			/// </summary>
			public static Point operator *(Point a, Point b)
			{
				return new Point(a.X * b.X, a.Y * b.Y);
			}
			/// <summary>
			/// Scalar multiplication of each member
			/// </summary>
			public static Point operator *(Point a, int b)
			{
				return new Point(a.X * b, a.Y * b);
			}
			/// <summary>
			/// Member-wise division
			/// </summary>
			public static Point operator /(Point a, Point b)
			{
				return new Point(a.X * b.X, a.Y * b.Y);
			}
			/// <summary>
			/// Scalar division of each member
			/// </summary>
			public static Point operator /(Point a, int b)
			{
				return new Point(a.X / b, a.Y / b);
			}

			public override string ToString()
			{
				return X + ", " + Y;
			}

		}

	}
}
