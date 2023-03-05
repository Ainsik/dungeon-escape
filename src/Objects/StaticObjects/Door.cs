namespace Dungeon_Crawl.src.StaticObjects
{
    internal class Door : StaticObject
    {
        public string Color { get; }
        public string Name { get => Color + " door"; }
        public Door(Position position, string color) : base(position)
        {
            Color = color;
        }
        public bool CanBeOpened(Key key)
        {
            return key.Color == Color;
        }

        protected override string Symbol => "D";
    }
}
