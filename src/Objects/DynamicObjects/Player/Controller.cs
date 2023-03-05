using Dungeon_Crawl.src.Core.View;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{
    internal abstract class Controller<T> where T : GameObject
    {
        protected readonly Map map;
        protected readonly Player player;
        protected int IgnoreItemSearching = 0;

        protected Controller(Map map, Player player)
        {
            this.map = map;
            this.player = player;
        }


        internal virtual State PickItem()
        {
            var item = SearchItem();
            IgnoreItemSearching = Math.Max(0, --IgnoreItemSearching);
            if (item is null || IgnoreItemSearching != 0) return State.Game;
            player.Info = GetInfo(item);
            return State.Info;
        }

        internal abstract void OnFound(bool accepted);
        protected abstract AskDialog GetInfo(T foundedItem);

        protected virtual T? SearchItem()
        {
            {
                if (GetItem(new Position(player.Position.X, player.Position.Y + 1)) is T item) return item;
            }
            {
                if (GetItem(new Position(player.Position.X, player.Position.Y - 1)) is T item) return item;
            }
            {
                if (GetItem(new Position(player.Position.X + 1, player.Position.Y)) is T item) return item;
            }
            {
                if (GetItem(new Position(player.Position.X - 1, player.Position.Y)) is T item) return item;
            }
            return null;
        }

        protected virtual T? GetItem(Position position)
        {
            if (map.At(position) is T)
            {
                return (T)map.At(position);
            }
            return null;
        }
    }
}