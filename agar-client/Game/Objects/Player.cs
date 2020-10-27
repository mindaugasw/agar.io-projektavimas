using System;
using System.Collections.Generic;
using System.Text;
using static agar_client.Game.Utils;

namespace agar_client.Game.Objects
{
	class Player : MapObject
	{

		//public int PLAYER_MOVE_SPEED = 35; // units per button press

		private PlayerStrategy strategy;

		public Player() : base()
		{
			strategy = new NormalStrategy();
		}
		public Player(string id, Point position) : base(id, position)
		{
			strategy = new NormalStrategy();
		}

		override public void CreateMapObject(Point? position)
		{
			var r = GameManager.Random;

			if (!position.HasValue)
				position = new System.Windows.Point(r.Next(0, 700), r.Next(0, 500)); // TODO remove hardcoded valus
			
			Position = position.Value;
			var color = System.Windows.Media.Color.FromRgb((byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(0, 256));
			Shape = GraphicsDrawer.CreateNewEllipse(50, color, Position);
		}

		public int playerMoveSpeed()
        {
			return strategy.playerSpeed();
		}

		public void changeStrategy(PlayerStrategy newStrategy)
        {
			strategy = newStrategy;

		}
	}
}
