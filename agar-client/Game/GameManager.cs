using agar_client.Game;
using agar_client.Game.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

		List<Food> food = new List<Food>();
		List<Virus> viruses = new List<Virus>();

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

		public void CreateFoodObjects() 
		{
			AbstractFactory foodFactory = new FoodFactory();
			foodFactory.createMapObjects();
			food = FoodFactory.Instance.food;
		}

		public void CreateVirusObjects() 
		{
			AbstractFactory virusFactory = new VirusFactory();
			virusFactory.createMapObjects();
			viruses = VirusFactory.Instance.viruses;
		}

		public void SendMapObjects() 
		{
			List<MapObject> mapObjects = new List<MapObject>();
			mapObjects.AddRange(food);
			mapObjects.AddRange(viruses);
			CommunicationManager.Instance.CreateMapObjects(mapObjects.Select(x => x.Id).ToArray(), mapObjects.Select(x => x.Name).ToArray(), mapObjects.Select(x => x.Position).ToArray());
		}

		public void ReceiveMapObjects(string[] ids, string[] mapObjectNames, Point[] positions)
		{
            for (int i = 0; i < ids.Length; i++)
			{
				Debug.WriteLine(positions[i]);
				switch (mapObjectNames[i])
				{
					case "GreenFood":
						food.Add(new GreenFood(ids[i], mapObjectNames[i], positions[i]));
						break;
					case "GreenVirus":
						viruses.Add(new GreenVirus(ids[i], mapObjectNames[i], positions[i]));
						break;
				}
			}
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
