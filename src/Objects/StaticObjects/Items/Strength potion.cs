namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class StrengthPotion : Consumable
{
    public StrengthPotion(Position position, Map map) : base(position, map)
    {
        Stats.Strength = 1;
        //Stats.Defense = 0;
        //Stats.HealthPoints = 0;
    }
    public override string Name => "Strength Potion";

}