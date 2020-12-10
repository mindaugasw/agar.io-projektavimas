using agar_client.Game;
using agar_client.Game.Objects;
using agar_client.Game.Objects.Adapter;
using agar_client.Game.Objects.Bridge;
using agar_client.Game.Objects.Builder;
using agar_client.Game.Objects.Factory;
using agar_client.Game.Objects.Iterator;
using agar_client.Game.Objects.State;
using agar_client.Game.Proxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using static agar_client.Game.Utils;

namespace agar_client
{
	public class GameManager
	{
		public static GameManager Instance;

		public static Random Random;

		public static bool IsTestEnvironment = false;

		public static LocalPlayer LocalPlayer;
		Dictionary<string, Player> players = new Dictionary<string, Player>();

		List<Food> food = new List<Food>();
		List<Virus> viruses = new List<Virus>();
		List<Poison> poison = new List<Poison>();

		public static Caretaker chatCareTaker = new Caretaker();

		public static Originator chatOriginator = new Originator();

		public static int mementoIdx = 1;
		public static int mementoMaxIdx = 1;

		public GameManager(bool testEnv = false)
		{
			IsTestEnvironment = testEnv;

			if (Instance == null)
				Instance = this;
			else
				throw new Exception();


			Random = new Random();

			//new CommunicationManager(); // Changed to Singleton-instatiation
			new InputHandler();

			// Design pattern #18 Proxy
			if (ConfigManager.Get<bool>("useGraphicsDrawerLoggerProxy"))
				new GraphicsDrawerLoggerProxy();
			else
				new GraphicsDrawer();

			Logger.Log("All services initialized");

			//LocalPlayer = new LocalPlayer();

			// Design pattern #6.1 Builder
			var concreteBuilder = new LocalPlayerBuilder();
			var director = new Director(concreteBuilder);
			director.Construct();
			LocalPlayer = (LocalPlayer)concreteBuilder.GetResult();

			new StatefulPowerupContext(); // Design pattern #17 State
		}

		public void CreateFoodObjects() 
		{
			AbstractFactory foodFactory = new FoodFactory();
			foodFactory.createMapObjects(null);
			//foodFactory.TemplateMethod(null);
			food = FoodFactory.Instance.food;

			// TO SHOW HOW CLONE WORKS

			// var redFood = new RedFood();
			// var copy = redFood.Clone();
			// GraphicsDrawer.MoveShape(copy.Shape, new Utils.Point(150, 10));
			// GraphicsDrawer.MoveShape(redFood.Shape, new Utils.Point(200, 10));


			// TO SHOW HOW DECORATOR WORKS

			// Food bigGreenFood = new BigFoodDecorator(new GreenFoodDecorator());
			// Food bigRedFood = new BigFoodDecorator(new RedFoodDecorator());

			// Food smallGreenFood = new SmallFoodDecorator(new GreenFoodDecorator());
			// Food smallRedFood = new SmallFoodDecorator(new RedFoodDecorator());

		}

		public void CreateVirusObjects() 
		{
            AbstractFactory virusFactory = new VirusFactory();
			virusFactory.createMapObjects(null);
			//virusFactory.TemplateMethod(null);
            viruses = VirusFactory.Instance.viruses;


            // TO SHOW HOW BRIDGE WORKS
            //Damage redVirus = new QuickDamageAction(new RedVirus());
            //Logger.Log("Red Virus:");
            //redVirus.InflictDamage();

            //Damage greenVirus = new QuickDamageAction(new GreenVirus());
            //Logger.Log("Green Virus:");
            //greenVirus.InflictDamage();


            //Damage redVirus2 = new SlowDamageAction(new RedVirus());
            //Logger.Log("Red Virus:");
            //redVirus2.InflictDamage();

            //Damage greenVirus2 = new SlowDamageAction(new GreenVirus());
            //Logger.Log("Green Virus:");
            //greenVirus2.InflictDamage();
        }

		public void CreatePoisonObjects()
		{
            PoisonFactory poisonFactory = new PoisonFactory();
            poisonFactory.createPoisonObjects(new Dictionary<string, int> { { "BluePoison", 1}, { "CyanPoison", 1}, {"DarkBluePoison", 1} });
            poison = PoisonFactory.Instance.poison;

            // TO SHOW HOW ADAPTER WORKS
            //BluePoison bluePoison = new BluePoison();
            //Food poisonAdapter = new BluePoisonAdapter(bluePoison);
            //poisonAdapter.FoodLogMessage();
        }

		public void SendMapObjects() 
		{
			//List<MapObject> mapObjects = new List<MapObject>();
			//mapObjects.AddRange(food);
			//mapObjects.AddRange(viruses);
			//mapObjects.AddRange(poison);
			//CommunicationManager.Instance.CreateMapObjects(mapObjects.Select(x => x.Id).ToArray(), mapObjects.Select(x => x.Name).ToArray(), mapObjects.Select(x => x.Position).ToArray());

			MapObject composite1 = VirusFactory.Instance.objects;
			MapObject composite2 = FoodFactory.Instance.objects;
			MapObject composite3 = PoisonFactory.Instance.poison2;


			composite1.AddRange(composite2.GetMapObjects());
			composite3.AddRange(composite1.GetMapObjects());

			string[] ids = new string[composite3.Count()];
			string[] mapObjectNames = new string[composite3.Count()];
			Point[] positions = new Point[composite3.Count()];
			// List Iteration
			for (IIterator iter = composite3.GetIterator(); iter.HasNext();)
            {
				MapObject x = (MapObject) iter.Next();
				ids[iter.Index()-1] = x.Id;
				mapObjectNames[iter.Index() - 1] = x.Name;
				positions[iter.Index() - 1] = x.Position;


			}
			CommunicationManager.Instance.CreateMapObjects(ids,mapObjectNames,positions);

			//Dictionary<int, MapObject> dicMapObj = new Dictionary<int, MapObject>();

			//Logger.Log("Array Iteration");
			//for (IIterator iter = new ArrayIterator(composite2.GetMapObjects().ToArray()); iter.HasNext();)
			//{
			//	MapObject x = (MapObject)iter.Next();
			//	dicMapObj.Add(iter.Index(), x);
			//	Logger.Log(x);
			//}

			//Logger.Log("Dictionary Iteration");
			//for (IIterator iter = new DictionaryIterator(dicMapObj); iter.HasNext();)
			//{
			//	MapObject x = (MapObject)iter.Next();
			//	Logger.Log(x);
			//}
		}

		public void ReceiveMapObjects(string[] ids, string[] mapObjectNames, Point[] positions)
		{
            for (int i = 0; i < ids.Length; i++)
			{
				Debug.WriteLine(positions[i]);
				switch (mapObjectNames[i])
				{
					case "GreenFood":
						food.Add(new BigFoodDecorator(new GreenFoodDecorator(ids[i], mapObjectNames[i], positions[i])));
						break;
					case "RedFood":
						food.Add( new SmallFoodDecorator(new RedFoodDecorator(ids[i], mapObjectNames[i], positions[i])));
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
			GraphicsDrawer.Instance.MoveShape(players[id].Shape, position);
		}
	}
}
