namespace Dungeon_Crawl.src.Objects
{
    public abstract class GameObject
    {
        public virtual bool IsPassable { get; } = false;

        protected abstract string Symbol { get; }
        public Position Position { get; set; }

        protected GameObject(Position position)
        {
            Position = position;
        }

        public abstract void Update();
        public abstract string Render();
        public override string ToString()
        {
            return Symbol;
        }
    }
}
