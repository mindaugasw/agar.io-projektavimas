using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using static agar_server.Game.Utils;

namespace agar_server.Game.Objects
{
	/// <summary>
	/// An object that is displayed on the game map (e.g. an obstacle, player)
	/// </summary>
	public class MapObject
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } // Unique object indentifier across whole server

		[JsonPropertyName("position")]
		public Point Position { get; set; }

	}
}
