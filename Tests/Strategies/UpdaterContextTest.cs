using System;
using System.Linq.Expressions;
using GildedRose.Application;
using Moq;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    [TestFixture]
    public class UpdaterContextTest
    {
        [TestCase(TestStrings.DefaultItemName, TestName = "UpdaterContextGetsDefaultStrategy", Category = TestStrings.StrategiesCategoryName)]
        public void GetsDefaultStrategy(string itemName)
        {
            AssertSameStrategy(itemName, f => f.CreateDefaultStrategy());
        }

        [TestCase(TestStrings.SulfurasItemName, TestName = "UpdaterContextGetsEmptyStrategy", Category = TestStrings.StrategiesCategoryName)]
        public void GetsEmptyStrategy(string itemName)
        {
            AssertSameStrategy(itemName, f => f.CreateEmptyStrategy());
        }

        [TestCase(TestStrings.AgedBrieItemName, TestName = "UpdaterContextGetsAgedBrieStrategy", Category = TestStrings.StrategiesCategoryName)]
        public void GetsAgedBrieStrategy(string itemName)
        {
            AssertSameStrategy(itemName, f => f.CreateAgedBrieStrategy());
        }

        [TestCase(TestStrings.BackstageItemName, TestName = "UpdaterContextGetsBackstageStrategy", Category = TestStrings.StrategiesCategoryName)]
        public void GetsBackstageStrategy(string itemName)
        {
            AssertSameStrategy(itemName, f => f.CreateBackstageStrategy());
        }

        [TestCase(TestStrings.ConjuredItemName, TestName = "UpdaterContextGetsConjuredStrategy", Category = TestStrings.StrategiesCategoryName)]
        public void GetsConjuredStrategy(string itemName)
        {
            AssertSameStrategy(itemName, f => f.CreateConjuredStrategy());
        }

        [TestCase(TestName = "UpdaterContextCallsUpdateQualityAndSellIn", Category = TestStrings.StrategiesCategoryName)]
        public void CallsUpdateQualityAndSellIn()
        {
            var item = new Item { Name = TestStrings.DefaultItemName };
            var factoryMock = CreateMockFactory();
            var strategyMock = CreateMockStrategy(string.Empty);
            factoryMock.Setup(f => f.CreateDefaultStrategy()).Returns(strategyMock.Object);

            var context = new UpdaterContext(factoryMock.Object);
            context.UpdateQuality(item);

            strategyMock.VerifyAll();
        }

        private void AssertSameStrategy(string itemName, Expression<Func<IUpdaterStrategyFactory, IUpdaterStrategy>> setUpExpression)
        {
            var item = new Item {Name = itemName};
            var factoryMock = CreateMockFactory();
            var strategyMock = CreateMockStrategy(itemName);
            factoryMock.Setup(setUpExpression).Returns(strategyMock.Object);

            var context = new UpdaterContext(factoryMock.Object);
            var strategy = context.GetStrategy(item);
            Assert.AreSame(strategyMock.Object, strategy);
        }

        private Mock<IUpdaterStrategyFactory> CreateMockFactory()
        {
            var factory = new Mock<IUpdaterStrategyFactory>();
            factory.Setup(f => f.CreateDefaultStrategy());
            factory.Setup(f => f.CreateEmptyStrategy());
            factory.Setup(f => f.CreateAgedBrieStrategy());
            factory.Setup(f => f.CreateBackstageStrategy());
            factory.Setup(f => f.CreateConjuredStrategy());
            return factory;
        }

        private Mock<IUpdaterStrategy> CreateMockStrategy(string name)
        {
            var strategy = new Mock<IUpdaterStrategy>();
            strategy.Setup(s => s.UpdateQuality(It.IsAny<Item>()));
            strategy.Setup(s => s.UpdateSellIn(It.IsAny<Item>()));
            strategy.Name = name;

            return strategy;
        }
    }
}
