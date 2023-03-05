namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class HealthPotion : Consumable
{
    public HealthPotion(Position position, Map map) : base(position, map)
    {
        //Stats.Strength = 0;
        //Stats.Defense = 0;
        Stats.HealthPoints = 20;
    }
    public override string Name => "Health Potion";

    public override State Use(Player player)
    {
        if (player.Stats.HealthPoints + Stats.HealthPoints > player.Level.maxHealtPoints)
        {
            return State.Game;
        }

        return base.Use(player);
    }
}
