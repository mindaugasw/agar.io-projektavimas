namespace agar_client.Tests.Game.Objects.Factory
{
    using agar_client.Game.Objects.Factory;
    using System;
    using Xunit;
    using agar_client.Game;

    public class BluePoisonTests // Generated Tests
    {
        private BluePoison _testClass;
        private string _id;
        private string _name;
        private Utils.Point _position;

        public BluePoisonTests()
        {
            TestsHelper.InitializeServices();
            _id = "TestValue752909914";
            _name = "TestValue1921882813";
            _position = new Utils.Point();
            _testClass = new BluePoison(_id, _name, _position);
        }

        [StaFact]
        public void CanConstruct()
        {
            var instance = new BluePoison();
            Assert.NotNull(instance);
            instance = new BluePoison(_id, _name, _position);
            Assert.NotNull(instance);
        }

        [StaTheory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new BluePoison(value, "TestValue1943887995", new Utils.Point()));
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