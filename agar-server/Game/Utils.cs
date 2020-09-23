using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace agar_server.Game
{
	public class Utils
	{
		/// <summary>
		/// Equivalent to Client.Utils.Point
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
		}
	}
}
