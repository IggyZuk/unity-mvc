using NUnit.Framework;

namespace Test
{
	[TestFixture]
	public class BoxTest
	{
		Model model;

		[SetUp]
		public void Init()
		{
			model = new Model();
		}

		[Test]
		public void TestAddBox()
		{
			for(int i = 0; i < 100; i++)
			{
				ModelService.AddBox(model, new Position());
			}
			Assert.AreEqual(100, model.boxes.Count);
		}

		[Test]
		public void TestEvents()
		{
			for(int i = 0; i < 100; i++)
			{
				ModelService.AddBox(model, new Position());
			}
			Assert.AreEqual(100, model.events.Count);
			Assert.That(model.events.Peek() is BoxAddedEvent);
		}

		[Test]
		public void TestTickBox()
		{
			Box box = ModelService.AddBox(model, new Position());

			Assert.AreEqual(1, model.boxes.Count);
			Assert.AreEqual(model.nextBoxId - 1, box.id);
			Assert.AreEqual(0, box.life);

			for(int i = 1; i <= 5; i++)
			{
				ModelService.Tick(model);
				Assert.AreEqual((float)i * Config.TICK_INTERVAL, box.life);
			}
		}
	}
}
