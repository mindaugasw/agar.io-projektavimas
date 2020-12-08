using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using agar_client;
using agar_client.Game;
using agar_client.Game.Objects;
using System.Windows.Shapes;

namespace agar_client.Tests.Patterns
{
	public class AbstractFactoryTests : IDisposable
	{
		public AbstractFactoryTests()
		{
			TestsHelper.InitializeServices();
		}

		public void Dispose()
		{
			TestsHelper.DisposeServices();
		}

		[StaFact]
		public void FoodFactoryTest()
		{
			FoodFactory foodFactory = new FoodFactory();
			Assert.IsType<FoodFactory>(foodFactory);
			Assert.NotNull(foodFactory.food);
		}

		[StaFact]
		public void FoodFactoryCreateObj()
		{
			FoodFactory foodFactory = new FoodFactory();
			foodFactory.createMapObjects(new Dictionary<string, int> { { "GreenFood", 1 }, { "RedFood", 1 } });
			Assert.Equal(4, foodFactory.food.Count);
			foodFactory.food = new List<Food>();
			foodFactory.createMapObjects(null);
			Assert.True(24.Equals(foodFactory.food.Count) || 22.Equals(foodFactory.food.Count));
			foodFactory.food = new List<Food>();
			foodFactory.createMapObjects(new Dictionary<string, int> { { "BluePoison", 1 }, { "RedFood", 1 } });
			Assert.NotEqual(4, foodFactory.food.Count);
		}

		[StaFact]
		public void VirusFactoryTest()
		{
			VirusFactory virusFactory = new VirusFactory();
			Assert.IsType<VirusFactory>(virusFactory);
			Assert.NotNull(virusFactory.viruses);
		}

		[StaFact]
		public void VirusFactoryCreateObj()
		{
			VirusFactory virusFactory = new VirusFactory();
			virusFactory.createMapObjects(new Dictionary<string, int> { { "GreenVirus", 1 }, { "RedVirus", 1 } });
			Assert.Equal(2, virusFactory.viruses.Count);
			virusFactory.viruses = new List<Virus>();
			virusFactory.createMapObjects(null);
			Assert.Equal(4, virusFactory.viruses.Count);
			virusFactory.viruses = new List<Virus>();
			virusFactory.createMapObjects(new Dictionary<string, int> { { "BluePoison", 1 }, { "RedVirus", 1 } });
			Assert.NotEqual(4, virusFactory.viruses.Count);
		}

		[StaFact]
		public void RedVirusTest()
		{
			RedVirus redVirus = new RedVirus("id_RedVirus", "RedVirus", new Utils.Point(11, 123));
			Assert.IsType<RedVirus>(redVirus);
			Assert.Equal(System.Windows.Media.Color.FromRgb(255, 0, 0), redVirus.getColor());
			Assert.Equal(80, redVirus.getSize());
			Assert.Equal("RedVirus", redVirus.Name);
			Assert.Equal(new Utils.Point(11, 123), redVirus.Position);
			Assert.Equal("id_RedVirus", redVirus.Id);
			Assert.Equal(2, redVirus.Shape.StrokeThickness);
			Assert.IsType<Polygon>(redVirus.Shape);
		}

		[StaFact]
		public void GreenVirusTest()
		{
			GreenVirus greenVirus = new GreenVirus("id_GreenVirus", "GreenVirus", new Utils.Point(11, 124));
			Assert.IsType<GreenVirus>(greenVirus);
			Assert.Equal(System.Windows.Media.Color.FromRgb(0, 255, 0), greenVirus.getColor());
			Assert.Equal(100, greenVirus.getSize());
			Assert.Equal("GreenVirus", greenVirus.Name);
			Assert.Equal(new Utils.Point(11, 124), greenVirus.Position);
			Assert.Equal("id_GreenVirus", greenVirus.Id);
			Assert.Equal(2, greenVirus.Shape.StrokeThickness);
			Assert.IsType<Polygon>(greenVirus.Shape);
		}

		[StaTheory]
		[MemberData(nameof(Data))]
		public void FoodFactoryFoodCount(Dictionary<string, int> food, int count)
		{
            FoodFactory foodFactory = new FoodFactory();
			foodFactory.createMapObjects(food);
            Assert.Equal(count, foodFactory.food.Count);
			FoodFactory.Instance = null;
        }

		public static IEnumerable<object[]> Data => 
			new List<object[]>
			{
				new object[] {new Dictionary<string, int> { { "GreenFood", 1 }, { "RedFood", 2 } }, 4},
				new object[] {new Dictionary<string, int> { { "GreenFood", 0 }, { "RedFood", 3 } }, 4},
				new object[] {new Dictionary<string, int> { { "BluePoison", 1 }, { "RedFood", 5 } }, 6},
				new object[] {new Dictionary<string, int> { { "GreenFood", 10 }, { "RedFood", 10 } }, 20},
				new object[] {new Dictionary<string, int> { { "GreenFood", 0 }, { "RedFood", 0 } }, 0},
			};
	}
}
