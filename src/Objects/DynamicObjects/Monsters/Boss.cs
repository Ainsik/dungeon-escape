using Dungeon_Crawl.src.Objects.DynamicObjects;

namespace Dungeon_Crawl.src.Monsters;

internal class Boss : Monster
{
    public Boss(Position position) : base(position)
    {
        Stats = new Stats();
        Stats.HealthPoints = 200;
        Stats.Strength = 30;
        Stats.Defense = 15;
    }

    protected override string Symbol => "B";

    internal override int experienceToGain => 150;

    public override string Render()
    {
        return "";
    }

    public override void Update()
    {
        return;
    }
}

