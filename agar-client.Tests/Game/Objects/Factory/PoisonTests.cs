namespace agar_client.Tests.Game.Objects.Factory
{
    using agar_client.Game.Objects.Factory;
    using System;
    using Xunit;
    using agar_client.Game;

    public class PoisonTests // Generated Tests
    {
        private class TestPoison : Poison
        {
            public TestPoison() : base()
            {
            }

            public TestPoison(string id, Utils.Point position) : base(id, position)
            {
            }

            public override void PoisonLogMessage()
            {
            }
        }

        private TestPoison _testClass;
        private string _id;
        private Utils.Point _position;

        public PoisonTests()
        {
            _id = "TestValue1697445515";
            _position = new Utils.Point();
            _testClass = new TestPoison(_id, _position);
        }

        [StaFact]
        public void CanConstruct()
        {
            TestsHelper.InitializeServices();
            var instance = new TestPoison();
            Assert.NotNull(instance);
            instance = new TestPoison(_id, _position);
            Assert.NotNull(instance);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new TestPoison(value, new Utils.Point()));
        }

        [Fact]
        public void CanCallCreateMapObject()
        {
            var position = new Utils.Point?();
            _testClass.CreateMapObject(position);
            Assert.True(true, "Create or modify test");
        }

        [Fact]
        public void CanCallgetSize()
        {
            var result = _testClass.getSize();
            Assert.True(true, "Create or modify test");
        }

        [Fact]
        public void CanCallgetColor()
        {
            var result = _testClass.getColor();
            Assert.True(true, "Create or modify test");
        }
    }
}