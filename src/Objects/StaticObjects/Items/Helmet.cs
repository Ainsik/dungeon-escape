namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
public class Helmet : Armor
{
    public Helmet(Position position, Map map, Rarity rarity = Rarity.Common) : base(position, map, rarity)
    {
        Stats.Defense = 2;
        ApplyRarityMultiplierToStats();
    }
    public override string Name => base.Name + "Helmet";

    public override EquipmentType equipmentType => EquipmentType.Helmet;
}