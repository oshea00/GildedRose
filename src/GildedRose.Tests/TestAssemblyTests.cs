using Xunit;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        Program _app;

        public TestAssemblyTests()
        {
            _app = new Program
            {
                Items = new List<Item>
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                        new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                        new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item
                            {
                                Name = "Backstage passes to a TAFKAL80ETC concert",
                                SellIn = 15,
                                Quality = 20
                            },
                        new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                    }
            };
        }

        [Fact]
        public void VestAfterUpdateQuality()
        {
            var vest = _app.Items.Single(i => i.Name.Contains("Vest"));
            var sellinBefore = vest.SellIn;
            var qualityBefore = vest.Quality;

            _app.UpdateQuality();

            Assert.Equal(vest.SellIn, sellinBefore - 1);
            Assert.Equal(vest.Quality, qualityBefore - 1);
        }
    }
}