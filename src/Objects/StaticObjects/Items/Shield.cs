namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
public class Shield : Armor
{
    public Shield(Position position, Map map, Rarity rarity = Rarity.Common) : base(position, map, rarity)
    {
        Stats.Defense = 3;
        ApplyRarityMultiplierToStats();
    }
    public override string Name => base.Name + "Shield";

    public override EquipmentType equipmentType => EquipmentType.Gloves;
}
