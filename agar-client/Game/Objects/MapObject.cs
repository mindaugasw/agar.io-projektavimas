using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;

namespace agar_client.Game.Objects
{
	/// <summary>
	/// An object that is displayed on the game map (e.g. an obstacle, player, etc)
	/// </summary>
	abstract class MapObject
	{
		public Point Position;
		public Shape Shape;

		string id; // Unique object indentifier (across whole server)

		public MapObject()
		{
			id = Utils.RandomString(16);
			CreateMapObject();
		}

		public abstract void CreateMapObject();

	}
}
