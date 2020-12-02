using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using agar_client.Game;
using agar_client.Game.Objects;

namespace agar_client.Tests.Patterns
{
    public class StrategyTests
	{
		[StaFact]
		public void StrategyTest()
		{
			PlayerStrategy strategy = new BoostStrategy();
			Assert.IsType<BoostStrategy>(strategy);
			Assert.Equal(55, strategy.playerSpeed());
			strategy = new NormalStrategy();
			Assert.IsType<NormalStrategy>(strategy);
			Assert.Equal(35, strategy.playerSpeed());
			strategy = new PoisonedStrategy();
			Assert.IsType<PoisonedStrategy>(strategy);
			Assert.Equal(15, strategy.playerSpeed());
			strategy = new SleepStrategy();
			Assert.IsType<SleepStrategy>(strategy);
			Assert.Equal(0, strategy.playerSpeed());
		}
	}
}
