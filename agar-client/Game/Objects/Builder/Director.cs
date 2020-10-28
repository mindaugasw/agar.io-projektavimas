using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Builder
{
	class Director
	{
		private IPlayerBuilder playerBuilder;

		public Director(IPlayerBuilder playerBuilder)
		{
			this.playerBuilder = playerBuilder;
		}

		public Player GetResult()
		{
			return playerBuilder.GetResult();
		}

		public void Construct()
		{
			playerBuilder.BuildPlayer();
			playerBuilder.BuildLocalPlayerIndicator();
		}
	}
}
