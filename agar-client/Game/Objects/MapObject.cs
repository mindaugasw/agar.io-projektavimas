using agar_client.Game.Objects.Iterator;
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
	public abstract class MapObject
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } // Unique object indentifier across whole server

		[JsonPropertyName("position")]
		public Point Position { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		public Shape Shape;

		private List<MapObject> objects = new List<MapObject>();

		public MapObject()
		{
			Id = Utils.RandomString(16);
			CreateMapObject(null);
		}
		public MapObject(string id, Point position)
		{
			if (id == null || id.Trim() == "")
			{
				throw new ArgumentNullException();
			}

			if (string.IsNullOrWhiteSpace(id))
				Id = Utils.RandomString(16);
			else
				Id = id;

			CreateMapObject(position);
		}

		public abstract void CreateMapObject(Point? position);

		public void Add(MapObject a)
		{
			objects.Add(a);
		}

		public void AddRange(List<MapObject> a)
		{
			objects.AddRange(a);
		}

		public void Remove(MapObject a)
		{
			objects.Remove(a);
		}

		public int Count()
		{
			return objects.Count;
		}

		public List<MapObject> GetMapObjects()
		{
			return objects;
		}

		public IIterator GetIterator()
		{
			return new ListIterator(objects);
		}

        public override string ToString()
        {
            return Name + ": " + Position;
        }
    }
}
