namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class ItemList
{
    private List<Item> Items;
    private static Random Random = new();

    public ItemList(Position position, Map map)
    {
        Items = new List<Item>()
        {
            new Sword(position, map, RandomRarity()),
            new Shield(position, map, RandomRarity()),
            new Helmet(position, map, RandomRarity()),
            new Greaves(position, map, RandomRarity()),
            new HealthPotion(position, map),
            new StrengthPotion(position, map),
            new DefensePotion(position, map),
        };
    }

    public Item RandomItem()
    {
        var random = new Random();
        var itemIndex = random.Next(Items.Count);
        var item = Items[itemIndex];
        return item;
    }
    private Rarity RandomRarity()
    {
        var randomNumber = Random.Next(0, 11);
        return randomNumber switch
        {
            >= 3 and <= 4 => Rarity.Common,
            > 4 and <= 7  => Rarity.Rare,
            8 => Rarity.Unique,
            9 => Rarity.Legendary,
            _ => Rarity.Normal,
        };
    }
}

