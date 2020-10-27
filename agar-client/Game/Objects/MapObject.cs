using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Shapes;
using static agar_client.Game.Utils;

namespace agar_client.Game.Objects
{
	/// <summary>
	/// An object that is displayed on the game map (e.g. an obstacle, player)
	/// </summary>
	abstract class MapObject
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } // Unique object indentifier across whole server

		[JsonPropertyName("position")]
		public Point Position { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		public Shape Shape;

		public MapObject()
		{
			Id = Utils.RandomString(16);
			CreateMapObject(null);
		}
		public MapObject(string id, Point position)
		{
			if (string.IsNullOrWhiteSpace(id))
				Id = Utils.RandomString(16);
			else
				Id = id;

			CreateMapObject(position);
		}

		public abstract void CreateMapObject(Point? position);
	}
}
