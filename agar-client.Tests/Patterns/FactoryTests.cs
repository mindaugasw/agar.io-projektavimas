﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using agar_client.Game;
using agar_client.Game.Objects;
using agar_client.Game.Objects.Factory;
using System.Windows.Shapes;

namespace agar_client.Tests.Patterns
{
    public class FactoryTests : IDisposable
    {
		public FactoryTests()
		{
			TestsHelper.InitializeServices();
		}

		public void Dispose()
		{
			TestsHelper.DisposeServices();
		}

		[StaFact]
		public void PoisonFactoryTest()
		{
			PoisonFactory poisonFactory = new PoisonFactory();
			Assert.IsType<PoisonFactory>(poisonFactory);
			Assert.NotNull(poisonFactory.poison);
		}

		[StaFact]
		public void PoisonFactoryCreatePoison()
		{
			PoisonFactory poisonFactory = new PoisonFactory();
			poisonFactory.createPoisonObjects(new Dictionary<string, int> { { "BluePoison", 1 }, { "CyanPoison", 1 } });
			Assert.Equal(2, poisonFactory.poison.Count);
			poisonFactory.poison = new List<Poison>();
			poisonFactory.createPoisonObjects(null);
			Assert.Equal(3, poisonFactory.poison.Count);
			poisonFactory.poison = new List<Poison>();
			poisonFactory.createPoisonObjects(new Dictionary<string, int> { { "BluePoison", 1 }, { "RedFood", 1 } });
			Assert.NotEqual(2, poisonFactory.poison.Count);
		}

		[StaFact]
		public void BluePoisonTest()
		{
			BluePoison bluePoison = new BluePoison("id_BluePoison", "BluePoison", new Utils.Point(11, 125));
			Assert.IsType<BluePoison>(bluePoison);
			Assert.Equal(System.Windows.Media.Color.FromRgb(0, 0, 255), bluePoison.getColor());
			Assert.Equal(10, bluePoison.getSize());
			Assert.Equal("BluePoison", bluePoison.Name);
			Assert.Equal(new Utils.Point(11, 125), bluePoison.Position);
			Assert.Equal("id_BluePoison", bluePoison.Id);
			Assert.Equal(2, bluePoison.Shape.StrokeThickness);
			Assert.IsType<Ellipse>(bluePoison.Shape);
		}

		[StaFact]
		public void CyanPoisonTest()
		{
			CyanPoison cyanPoison = new CyanPoison("id_CyanPoison", "CyanPoison", new Utils.Point(11, 126));
			Assert.IsType<CyanPoison>(cyanPoison);
			Assert.Equal(System.Windows.Media.Color.FromRgb(0, 255, 255), cyanPoison.getColor());
			Assert.Equal(10, cyanPoison.getSize());
			Assert.Equal("CyanPoison", cyanPoison.Name);
			Assert.Equal(new Utils.Point(11, 126), cyanPoison.Position);
			Assert.Equal("id_CyanPoison", cyanPoison.Id);
			Assert.Equal(2, cyanPoison.Shape.StrokeThickness);
			Assert.IsType<Ellipse>(cyanPoison.Shape);
		}

		[StaFact]
		public void DarkBluePoison()
		{
			DarkBluePoison darkBluePoison = new DarkBluePoison("id_DarkBluePoison", "DarkBluePoison", new Utils.Point(11, 127));
			Assert.IsType<DarkBluePoison>(darkBluePoison);
			Assert.Equal(System.Windows.Media.Color.FromRgb(0, 0, 139), darkBluePoison.getColor());
			Assert.Equal(10, darkBluePoison.getSize());
			Assert.Equal("DarkBluePoison", darkBluePoison.Name);
			Assert.Equal(new Utils.Point(11, 127), darkBluePoison.Position);
			Assert.Equal("id_DarkBluePoison", darkBluePoison.Id);
			Assert.Equal(2, darkBluePoison.Shape.StrokeThickness);
			Assert.IsType<Ellipse>(darkBluePoison.Shape);
		}
	}
}
