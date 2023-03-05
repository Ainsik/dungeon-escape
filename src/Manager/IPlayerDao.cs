namespace Dungeon_Crawl.src.Manager
{
    public interface IPlayerDao
    {

        public void Add(Player player);
        public Player Get(Map map);
        string SerializeToXml<T>(T value);
        public void Update(Player player);
        T XmlDeserializeFromString<T>(string objectData);
    }
}