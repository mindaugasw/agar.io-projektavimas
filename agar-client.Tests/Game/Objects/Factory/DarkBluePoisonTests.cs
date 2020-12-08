namespace agar_client.Tests.Game.Objects.Factory
{
    using agar_client.Game.Objects.Factory;
    using System;
    using Xunit;
    using agar_client.Game;

    public class DarkBluePoisonTests
    {
        private DarkBluePoison _testClass;
        private string _id;
        private string _name;
        private Utils.Point _position;

        public DarkBluePoisonTests()
        {
            TestsHelper.InitializeServices();
            _id = "TestValue936812396";
            _name = "TestValue91292943";
            _position = new Utils.Point();
            _testClass = new DarkBluePoison(_id, _name, _position);
        }

        [StaFact]
        public void CanConstruct()
        {
            var instance = new DarkBluePoison();
            Assert.NotNull(instance);
            instance = new DarkBluePoison(_id, _name, _position);
            Assert.NotNull(instance);
        }

        [StaTheory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new DarkBluePoison(value, "TestValue1530965513", new Utils.Point()));
        }

        [StaFact]
        public void CanCallCreateMapObject()
        {
            var position = new Utils.Point?();
            _testClass.CreateMapObject(position);
            Assert.True(true, "Create or modify test");
        }

        [StaFact]
        public void CanCallPoisonLogMessage()
        {
            _testClass.PoisonLogMessage();
            Assert.True(true, "Create or modify test");
        }
    }
}