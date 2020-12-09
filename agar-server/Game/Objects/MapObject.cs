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
	public abstract class MapObject
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } // Unique object indentifier across whole server

        [JsonPropertyName("position")]
		public Point Position { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }


		public MapObject()
		{
		}
		public MapObject(string id, Point position, string name)
		{
			Id = id;
			Position = position;
			Name = name;
		}

		public MapObject Clone()
        {
            var copy = (MapObject) this.MemberwiseClone();
            return copy;
        }
	}
}
