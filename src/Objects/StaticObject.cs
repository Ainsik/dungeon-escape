namespace Dungeon_Crawl.src.Objects
{
    public abstract class StaticObject : GameObject
    {
        public StaticObject(Position position) : base(position)
        {
        }


        public override string Render()
        {
            return Symbol;
        }
        public override void Update() { }
    }
}
