using agar_client.Game;
using agar_client.Game.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static agar_client.Game.Utils;

namespace agar_client
{
	class GameManager
	{
		public static GameManager Instance;

		public static Random Random;

		LocalPlayer LocalPlayer;
		Dictionary<string, Player> players = new Dictionary<string, Player>();


		public GameManager()
		{
			if (Instance == null)
				Instance = this;
			else
				throw new Exception();


			Random = new Random();

			//new CommunicationManager(); // Changed to Singleton-instatiation
			new InputHandler();
			new GraphicsDrawer();

			Logger.Log("All services initialized");

			LocalPlayer = new LocalPlayer();
		}

		public void CreatePlayer(string id, Point position)
		{
			var player = new Player(id, position);
			players.Add(id, player);
		}

		public void MovePlayer(string id, Point position)
		{
			GraphicsDrawer.MoveShape(players[id].Shape, position);
		}
	}
}
