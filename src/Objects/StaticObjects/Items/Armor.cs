namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
public abstract class Armor : Item
{
    private readonly Rarity _rarity;

    public Armor(Position position, Map map, Rarity rarity) : base(position, map)
    {
        _rarity = rarity;
    }


    public override string Name => $"{_rarity} ";
    protected virtual float GetRarityMultiplier()
    {
        return _rarity switch
        {
            Rarity.Normal => 1.0f,
            Rarity.Common => 1.25f,
            Rarity.Rare => 1.5f,
            Rarity.Unique => 2.0f,
            Rarity.Legendary => 3.0f,
            _ => throw new NotImplementedException(),
        };
    }
    protected virtual void ApplyRarityMultiplierToStats()
    {
        Stats.HealthPoints = (int) Math.Round(GetRarityMultiplier() * Stats.HealthPoints);
        Stats.Strength = (int) Math.Round(GetRarityMultiplier() * Stats.Strength);
        Stats.Defense = (int) Math.Round(GetRarityMultiplier() * Stats.Defense);
    }
    public abstract EquipmentType equipmentType { get; }
    public override State Use(Player player)
    {
        player.Inventory.Equipment.Equip(this);
        return State.Game;
    }
}

