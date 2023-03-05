namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
public class Greaves : Armor
{
    public Greaves(Position position, Map map, Rarity rarity = Rarity.Common) : base(position, map, rarity)
    {
        Stats.Defense = 2;
        ApplyRarityMultiplierToStats();
    }
    public override string Name => base.Name + "Greaves";

    public override EquipmentType equipmentType => EquipmentType.Greaves;
}
