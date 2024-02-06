using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdateQualityMethod_ShouldHaveNotChangeName()
        {
            // Arrange
            var items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
            var gildedRoseApp = new GildedRose(items);

            // Act
            gildedRoseApp.UpdateQuality();

            // Assert
            Assert.AreEqual("foo", items[0].Name);
        }
    }
}
