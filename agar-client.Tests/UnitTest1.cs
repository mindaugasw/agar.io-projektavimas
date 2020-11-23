using NUnit.Framework;

namespace agar_client.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestPass()
		{
			Assert.Pass();
		}

		[Test]
		public void TestFail()
		{
			Assert.Fail();
		}
	}
}