﻿using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Builder
{
	interface IPlayerBuilder
	{
		public void BuildPlayer();

		public void BuildLocalPlayerIndicator();

		public Player GetResult();
	}
}
