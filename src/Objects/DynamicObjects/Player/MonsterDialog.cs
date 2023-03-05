using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{
    internal class MonsterDialog : Controller<Monster>
    {
        public MonsterDialog(Map map, Player player) : base(map, player)
        {
        }

        protected override AskDialog GetInfo(Monster foundedItem)
        {
            return new InfoDialog(foundedItem.GetNextPhrase(), "Ok", OnFound);
        }

        protected override Monster? SearchItem()
        {
            var foundItem = base.SearchItem();
            if (foundItem is null) return null;
            return foundItem.Finished ? null : foundItem;
        }

        internal override void OnFound(bool accepted)
        {
        }
    }
}
