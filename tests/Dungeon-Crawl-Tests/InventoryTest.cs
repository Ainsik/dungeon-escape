using Dungeon_Crawl.src.Actions;
using Dungeon_Crawl.src.Objects.DynamicObjects.Player;
using Dungeon_Crawl.src.Objects;
using Dungeon_Crawl.src.Objects.StaticObjects.Items;
using Dungeon_Crawl.src.Core;

namespace Dungeon_Crawl_Tests
{
    public class Tests
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
        public void TestAddedItemToInventoryIsInInventory()
        {
            var item = new Sword(new Position(0,0), _map);
            var expectedInventory = new List<Item> { item };

            _inventory.AddItem(item);
            var actualInventory = _inventory.GetItems();

            Assert.That(actualInventory, Is.EqualTo(expectedInventory));
        }

        [Test]
        public void TestRemoveItemFromInventory()
        {
            var item = new Sword(new Position(0,0), _map);
            var expectedInventory = new List<Item> {  };

            _inventory.AddItem(item);
            _inventory.RemoveItem(item);
            var actualInventory = _inventory.GetItems();

            Assert.That(actualInventory, Is.EqualTo(expectedInventory));
        }
    }
}