namespace agar_client.Tests.Game.Objects.Factory
{
    using agar_client.Game.Objects.Factory;
    using System;
    using Xunit;
    using agar_client.Game;

    public class CyanPoisonTests
    {
        private CyanPoison _testClass;
        private string _id;
        private string _name;
        private Utils.Point _position;

        public CyanPoisonTests()
        {
            TestsHelper.InitializeServices();
            _id = "TestValue198978659";
            _name = "TestValue1557048726";
            _position = new Utils.Point();
            _testClass = new CyanPoison(_id, _name, _position);
        }

        [StaFact]
        public void CanConstruct()
        {
            var instance = new CyanPoison();
            Assert.NotNull(instance);
            instance = new CyanPoison(_id, _name, _position);
            Assert.NotNull(instance);
        }

        [StaTheory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new CyanPoison(value, "TestValue1652115468", new Utils.Point()));
        }
    }
}