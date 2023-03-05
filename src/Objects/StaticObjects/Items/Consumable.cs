using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl.src.Objects.StaticObjects.Items
{
    internal abstract class Consumable : Item
    {
        protected Consumable(Position position, Map map) : base(position, map)
        {
        }
        public override State Use(Player player)
        {
            player.Stats.UpdateStats(Stats.HealthPoints, Stats.Strength, Stats.Defense);
            player.Inventory.RemoveItem(this);
            return State.Game;
        }
    }
}
