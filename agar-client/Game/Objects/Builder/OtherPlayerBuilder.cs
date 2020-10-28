using System;
using System.Collections.Generic;
using System.Text;
using static agar_client.Game.Utils;

namespace agar_client.Game.Objects.Builder
{
	// Concrete builder #2
	class OtherPlayerBuilder : IPlayerBuilder
	{
		private Player player;

		private string id;
		private Point position;

		public OtherPlayerBuilder(string id, Point position)
		{
			this.id = id;
			this.position = position;
		}

		public void BuildPlayer()
		{
			player = new Player(id, position);
		}

		public void BuildLocalPlayerIndicator()
		{
		}

		public Player GetResult()
		{
			return player;
		}
	}
}
