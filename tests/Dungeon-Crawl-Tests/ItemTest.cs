using Dungeon_Crawl.src.Actions;
using Dungeon_Crawl.src.Core;
using Dungeon_Crawl.src.Objects;
using Dungeon_Crawl.src.Objects.DynamicObjects.Player;
using Dungeon_Crawl.src.Objects.StaticObjects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl_Tests
{
    [TestFixture]
    internal class ItemTest
    {
        private Inventory _inventory;
        private Map _map;
        [SetUp]
        public void Setup()
        {
            _map = new Map();
            var player = new Player(new Position(0, 0), new Movement(_map), _map);
            _inventory = new Inventory(player);
        }
        [Test]
        public void LegendarySword3TimesBetterThenNormal()
        {
            var normalItem = new Sword(new Position(0,0), _map, Rarity.Normal);
            var legendaryItem = new Sword(new Position(0,0), _map, Rarity.Legendary);

            var normalStrength = normalItem.Stats.Strength;
            var legendaryStrength = legendaryItem.Stats.Strength;
            var actualDifference = legendaryStrength / normalStrength;

            Assert.That(actualDifference, Is.EqualTo(3));
        }

    }
}
