namespace Dungeon_Crawl.src.Objects.StaticObjects
{
    internal class Air : StaticObject
    {
        public override bool IsPassable => true;
        public Air(Position position) : base(position)
        {
        }

        protected override string Symbol => " "; 
    }
}
