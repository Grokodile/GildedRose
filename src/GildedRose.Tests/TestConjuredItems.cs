using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class TestConjuredItems
    {

        /*
         * We have recently signed a supplier of conjured items. This requires an update to our system:
         * - "Conjured" items degrade in Quality twice as fast as normal items
         */

        [Test]
        public void GivenStockContainsConjuredItemAndConjuredItemsFeatureIsEnabled_WhenUpdatingQuality_ThenConjuredItemQualityHasDecreasedByTwo()
        {
            Program.Main(new[] {"0", "FeatureType.Conjured == true"});

            var itemsWithNoUpdates = Program.Items;

            Program.Main(new []{"1", "FeatureType.Conjured == true"});

            var itemsWithOneUpdate = Program.Items;
            
            Program.Main(new []{"51", "FeatureType.Conjured == true"});

            var itemsWithFiftyOneUpdates = Program.Items;


            var normalItemWithNoUpdate = itemsWithNoUpdates.Single(i => i.Name == "Elixir of the Mongoose");
            var normalItemWithOneUpdate = itemsWithOneUpdate.Single(i => i.Name == "Elixir of the Mongoose");
            var normalItemWithFiftyOneUpdates = itemsWithFiftyOneUpdates.Single(i => i.Name == "Elixir of the Mongoose");
            var conjuredItemWithNoUpdate = itemsWithNoUpdates.First(i => i.Name == "Conjured Mana Cake");
            var conjuredItemWithOneUpdate = itemsWithOneUpdate.First(i => i.Name == "Conjured Mana Cake");
            var conjuredItemWithFiftyOneUpdates = itemsWithFiftyOneUpdates.First(i => i.Name == "Conjured Mana Cake");

            Assert.That(normalItemWithNoUpdate.SellIn,Is.EqualTo(5));
            Assert.That(normalItemWithNoUpdate.Quality,Is.EqualTo(7));
            Assert.That(normalItemWithOneUpdate.SellIn,Is.EqualTo(4));
            Assert.That(normalItemWithOneUpdate.Quality,Is.EqualTo(6));
            Assert.That(normalItemWithFiftyOneUpdates.SellIn,Is.EqualTo(-46));
            Assert.That(normalItemWithFiftyOneUpdates.Quality,Is.EqualTo(0));
            Assert.That(conjuredItemWithNoUpdate.SellIn,Is.EqualTo(3));
            Assert.That(conjuredItemWithNoUpdate.Quality,Is.EqualTo(6));
            Assert.That(conjuredItemWithOneUpdate.SellIn,Is.EqualTo(2));
            Assert.That(conjuredItemWithOneUpdate.Quality,Is.EqualTo(4));
            Assert.That(conjuredItemWithFiftyOneUpdates.SellIn,Is.EqualTo(-48));
            Assert.That(conjuredItemWithFiftyOneUpdates.Quality, Is.EqualTo(0));
        }
    }
}
