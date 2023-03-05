using Dungeon_Crawl.src.Core.View;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{
    internal class ItemController : Controller<Item>
    {
        public ItemController(Map map, Player player) : base(map, player)
        {

        }

        internal override void OnFound(bool accepted)
        {
            if (accepted)
            {
                var item = SearchItem();
                item?.PickUp(player);
            }
            else
            {
                IgnoreItemSearching = 2;
            }
            player.Info = null;
        }

        protected override AskDialog GetInfo(Item foundedItem)
        {
            return new AskDialog($"Pick {foundedItem.Name}?", new Tuple<string, string>("Yes", "No"), OnFound);
        }
    }
}