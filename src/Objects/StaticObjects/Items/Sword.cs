namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
public class Sword : Armor
{
    public Sword(Position position, Map map, Rarity rarity = Rarity.Common) : base(position, map, rarity)
    {
        Stats.Strength = 3;
        ApplyRarityMultiplierToStats();
    }

    public override string Name => base.Name + "Sword";

    public override EquipmentType equipmentType => EquipmentType.Weapon;
}

