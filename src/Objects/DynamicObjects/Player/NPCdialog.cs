using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Crawl.src.Core.View;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{
    internal class NPCdialog : Controller<NPC>
    {
        public NPCdialog(Map map, Player player) : base(map, player)
        {
        }

        protected override AskDialog GetInfo(NPC foundedItem)
        {
            return new InfoDialog(foundedItem.GetNextPhrase(), "Ok", OnFound);
        }

        protected override NPC? SearchItem()
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
