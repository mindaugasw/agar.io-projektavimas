using System;
using Xunit;
using agar_client;
using agar_client.Game;
using agar_client.Game.Objects.Builder;
using agar_client.Game.Objects;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace agar_client.Tests
{
	//[collection: CollectionDefinition(DisableParallelization = true)] // Hangs up second test
	public class BuilderTests : IDisposable
	{
		public BuilderTests()
		{
			TestsHelper.InitializeServices();
		}

		public void Dispose()
		{
			TestsHelper.DisposeServices();
		}

		[StaFact]
		public void LocalPlayerBuilderTest()
		{
			var localBuilder = new LocalPlayerBuilder();
			var localDirector = new Director(localBuilder);
			localDirector.Construct();

			var result = localDirector.GetResult();

			Assert.IsType<LocalPlayer>(result);
			Assert.NotNull(result.Shape);
			Assert.Equal(3, result.Shape.StrokeThickness);
		}

		[StaFact]
		public void OtherPlayerBuilderTest()
		{
			var otherBuilder = new OtherPlayerBuilder("id_string", new Utils.Point(11, 22));
			var otherDirector = new Director(otherBuilder);
			otherDirector.Construct();

			var result = otherDirector.GetResult();

			Assert.IsType<Player>(result);
			Assert.NotNull(result.Shape);
			Assert.Equal(2, result.Shape.StrokeThickness);

			Assert.Equal("id_string", result.Id);
			Assert.Equal(new Utils.Point(11, 22), result.Position);
		}
	}
}
