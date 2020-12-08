namespace agar_client.Tests.Game.Objects
{
    using agar_client.Game.Objects;
    using System;
    using Xunit;
    using agar_client.Game;

    public class GreenVirusTests // Generated Tests
    {
        private GreenVirus _testClass;
        private string _id;
        private string _name;
        private Utils.Point _position;

        public GreenVirusTests()
        {
            TestsHelper.InitializeServices();
            _id = "TestValue1748748960";
            _name = "TestValue2119498639";
            _position = new Utils.Point();
            _testClass = new GreenVirus(_id, _name, _position);
        }

        [StaFact]
        public void CanConstruct()
        {
            var instance = new GreenVirus();
            Assert.NotNull(instance);
            instance = new GreenVirus(_id, _name, _position);
            Assert.NotNull(instance);
        }

        [StaTheory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new GreenVirus(value, "TestValue1691755836", new Utils.Point()));
        }

        [StaFact]
        public void CanCallCreateMapObject()
        {
            var position = new Utils.Point?();
            _testClass.CreateMapObject(position);
            Assert.True(true, "Create or modify test");
        }
    }
}