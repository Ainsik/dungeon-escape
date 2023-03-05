namespace Dungeon_Crawl.src.Monsters;

internal class Warrior : Monster
{
    public override Stats Stats { get; internal set; }
    public Warrior(Position position) : base(position)
    {
        Stats = new Stats();
        Stats.HealthPoints = 60;
        Stats.Strength = 12;
        Stats.Defense = 3;
    }
    internal override int experienceToGain => 30;
    public override int maxMonsterHP => 60;
    protected override string Symbol => "W";

    public override void Update()
    {
        return;
    }

    public override string Render()
    {
        return "";
    }
}

