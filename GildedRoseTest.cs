using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        private const int SULFURAS_QUALITY = 80;

        private const int MAX_QUALITY = 50;

        private const int MIN_QUALITY = 0;


        [TestCase(ProductLibrary.PRODUCT_STANDARD)]
        [TestCase(ProductLibrary.PRODUCT_AGED_BRIE)]
        [TestCase(ProductLibrary.PRODUCT_BACKSTAGE_PASSES)]
        public void WhenItemIsNotSulfuras_SellInIsDecreasing(string product)
        {
            // Init
            int initialSellIn = 20; 
            var item = new Item { Name = product, SellIn = initialSellIn, Quality = 49 };
            var app = new GildedRose(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(initialSellIn - 1, item.SellIn);
        }

        [TestCase(ProductLibrary.PRODUCT_STANDARD)]
        [TestCase(ProductLibrary.PRODUCT_AGED_BRIE)]
        [TestCase(ProductLibrary.PRODUCT_BACKSTAGE_PASSES)]
        public void WhenItemIsStandard_QualityIsCapped(string product)
        {
            // Init
            var item = new Item { Name = product, SellIn = 11, Quality = 50 };
            var app = new GildedRose(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.LessOrEqual(item.Quality, MAX_QUALITY);
        }
     
        [TestCase(ProductLibrary.PRODUCT_STANDARD)]
        [TestCase(ProductLibrary.PRODUCT_AGED_BRIE)]
        [TestCase(ProductLibrary.PRODUCT_SULFURAS)]
        [TestCase(ProductLibrary.PRODUCT_BACKSTAGE_PASSES)]
        public void WithAnyItems_QualityNeverBelowMin(string product)
        {
            // Init
            var item = new Item { Name = product, SellIn = 11, Quality = 0 };

            // Act
            var app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();

            // Assert
            Assert.GreaterOrEqual(item.Quality, MIN_QUALITY);
        }

        [TestCase(0)]
        [TestCase(25)]
        [TestCase(50)]
        [TestCase(80)]
        public void WhenItemIsSulfuras_QualityNeverAltered(int quality)
        {
            // Init
            var item = new Item { Name = ProductLibrary.PRODUCT_SULFURAS, SellIn = 11, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.LessOrEqual(item.Quality, SULFURAS_QUALITY);
        }

        [TestCase(-1)]
        [TestCase(25)]
        [TestCase(50)]
        [TestCase(80)]
        public void WhenItemIsSulfuras_ItemIsNeverSoldOut(int sellIn)
        {
            // Init
            var item = new Item { Name = ProductLibrary.PRODUCT_SULFURAS, SellIn = sellIn, Quality = SULFURAS_QUALITY };
            var app = new GildedRose(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(sellIn, item.SellIn);
        }

        [TestCase(0)]
        [TestCase(25)]
        public void WhenItemIsAgedBrie_QualityIncreases(int quality)
        {
            // Init
            var item = new Item { Name = ProductLibrary.PRODUCT_AGED_BRIE, SellIn = 11, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(quality + 1, item.Quality);
        }

        [TestCase(2)]
        [TestCase(50)]
        public void WhenStandardProductSellInPassed_QualityIsDegradingTwiceAsFast(int quality)
        {
            // Init
            var item = new Item { Name = ProductLibrary.PRODUCT_STANDARD, SellIn = -1, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(quality - 2, item.Quality);
        }

        [TestCase(2)]
        [TestCase(48)]
        public void WhenAgedBrieProductSellInPassed_QualityIsIncreasingTwiceAsFast(int quality)
        {
            // Init
            var item = new Item { Name = ProductLibrary.PRODUCT_AGED_BRIE, SellIn = -1, Quality = quality };
            var app = new GildedRose(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(quality + 2, item.Quality);
        }

        [TestCase(25, 1)]
        [TestCase(10, 2)]
        [TestCase(6, 2)]
        [TestCase(5, 3)]
        [TestCase(1, 3)]
        public void WhenItemIsBackstage_QualityIsIncreasing(int sellInn, int increaseSpeed)
        {
            // Init
            int initialQuality = 25;
            var item = new Item { Name = ProductLibrary.PRODUCT_BACKSTAGE_PASSES, SellIn = sellInn, Quality = initialQuality };
            var app = new GildedRose(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(initialQuality + increaseSpeed, item.Quality);
        }

        public void WhenItemIsBackstage_QualityIsZeroAfterConcert()
        {
            // Init
            var item = new Item { Name = ProductLibrary.PRODUCT_BACKSTAGE_PASSES, SellIn = -1, Quality = 25 };
            var app = new GildedRose(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, item.Quality);
        }
    }
}
