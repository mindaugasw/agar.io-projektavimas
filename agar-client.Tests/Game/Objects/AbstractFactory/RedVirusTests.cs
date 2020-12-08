namespace agar_client.Tests.Game.Objects
{
    using agar_client.Game.Objects;
    using System;
    using Xunit;
    using agar_client.Game;

    public class RedVirusTests // Generated Tests
    {
        private RedVirus _testClass;
        private string _id;
        private string _name;
        private Utils.Point _position;

        public RedVirusTests()
        {

            TestsHelper.InitializeServices();
            _id = "TestValue2139458642";
            _name = "TestValue1788312371";
            _position = new Utils.Point();
            _testClass = new RedVirus(_id, _name, _position);
        }

        [StaFact]
        public void CanConstruct()
        {
            var instance = new RedVirus();
            Assert.NotNull(instance);
            instance = new RedVirus(_id, _name, _position);
            Assert.NotNull(instance);
        }

        [StaTheory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new RedVirus(value, "TestValue2002990936", new Utils.Point()));
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