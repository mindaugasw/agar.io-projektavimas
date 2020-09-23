using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;

namespace agar_client.Game.Objects
{
	class Player : MapObject
	{

		public const int PLAYER_MOVE_SPEED = 35; // units per button press

		public Player() : base()
		{
		}

		override public void CreateMapObject()
		{
			var r = GameManager.Random;

			var position = new System.Windows.Point(r.Next(0, 700), r.Next(0, 500)); // TODO remove hardcoded valus
			Position = position;
			var color = System.Windows.Media.Color.FromRgb((byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(0, 256));
			Shape = GraphicsDrawer.CreateNewEllipse(50, color, position);
		}
	}
}
