namespace Dungeon_Crawl.src.StaticObjects
{
    internal class Border : StaticObject
    {
        public Border(Position position) : base(position)
        {
        }

        protected override string Symbol { get; }
    }
}
