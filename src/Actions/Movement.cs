using Dungeon_Crawl.src.Core;

namespace Dungeon_Crawl.src.Actions
{
    public class Movement
    {
        private Map _map;
        private FightArea _area;
        public Movement(Map map)
        {
            _map = map;
        }
        public Movement(FightArea fightArea)
        {
            _area = fightArea;
        }
        private bool IsValidMove(Position positionTo)
        {
            var destination = _map.At(positionTo);
            var InMapBounds = positionTo.X >= 0 && positionTo.Y >= 0 && positionTo.X < _map.Width && positionTo.Y < _map.Height;

            return destination.IsPassable && InMapBounds;
        }
        public bool Move(Position positionFrom, Position positionTo)
        {
            if (!IsValidMove(positionTo))
                return false;

            _map.ChangePositions(positionFrom, positionTo);
            return true;
        }

    }
}
