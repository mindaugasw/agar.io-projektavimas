using agar_client.Game;
using agar_client.Game.Objects;
using agar_client.Game.Objects.Builder;
using agar_client.Game.Objects.Factory;
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
		List<Poison> poison = new List<Poison>();

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

			//LocalPlayer = new LocalPlayer();

			// Design pattern #6.1 Builder
			var concreteBuilder = new LocalPlayerBuilder();
			var director = new Director(concreteBuilder);
			director.Construct();
			LocalPlayer = (LocalPlayer)concreteBuilder.GetResult();
		}

		public void CreateFoodObjects() 
		{
			// AbstractFactory foodFactory = new FoodFactory();
			// foodFactory.createMapObjects();
			// food = FoodFactory.Instance.food;

			var redFood = new RedFood();

			// TO SHOW HOW CLONE WORKS
			var copy = redFood.Clone();
			GraphicsDrawer.MoveShape(copy.Shape, new Utils.Point(150, 10));
			GraphicsDrawer.MoveShape(redFood.Shape, new Utils.Point(200, 10));

			Food bigGreenFood = new BigFoodDecorator(new GreenFood());

		}

		public void CreateVirusObjects() 
		{
			AbstractFactory virusFactory = new VirusFactory();
			virusFactory.createMapObjects();
			viruses = VirusFactory.Instance.viruses;
		}

		public void CreatePoisonObjects()
		{
			PoisonFactory poisonFactory = new PoisonFactory();
			poisonFactory.createPoisonObjects();
			poison = PoisonFactory.Instance.poison;
		}

		public void SendMapObjects() 
		{
			List<MapObject> mapObjects = new List<MapObject>();
			mapObjects.AddRange(food);
			mapObjects.AddRange(viruses);
			mapObjects.AddRange(poison);
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
					case "RedFood":
						food.Add(new RedFood(ids[i], mapObjectNames[i], positions[i]));
						break;
					case "GreenVirus":
						viruses.Add(new GreenVirus(ids[i], mapObjectNames[i], positions[i]));
						break;
					case "RedVirus":
						viruses.Add(new RedVirus(ids[i], mapObjectNames[i], positions[i]));
						break;
					case "BluePoison":
						poison.Add(new BluePoison(ids[i], mapObjectNames[i], positions[i]));
						break;
					case "CyanPoison":
						poison.Add(new CyanPoison(ids[i], mapObjectNames[i], positions[i]));
						break;
					case "DarkBluePoison":
						poison.Add(new DarkBluePoison(ids[i], mapObjectNames[i], positions[i]));
						break;
				}
			}
		}

		public void CreatePlayer(string id, Point position)
		{
			//var player = new Player(id, position);

			// Design pattern #6.2 Builder
			var concreteBuilder = new OtherPlayerBuilder(id, position);
			var director = new Director(concreteBuilder);
			director.Construct();
			var player = concreteBuilder.GetResult();

			players.Add(id, player);
		}

		public void MovePlayer(string id, Point position)
		{
			GraphicsDrawer.MoveShape(players[id].Shape, position);
		}
	}
}
