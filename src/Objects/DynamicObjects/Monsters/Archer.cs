namespace Dungeon_Crawl.src.Monsters;

internal class Archer : Monster
{
    public override Stats Stats { get; internal set; }
    public Archer(Position position) : base(position)
    {
        Stats = new Stats();
        Stats.HealthPoints = 45;
        Stats.Strength = 10;
        Stats.Defense = 2;
    }
    internal override int experienceToGain => 20;
    public override int maxMonsterHP => 45;

    protected override string Symbol => "A";

    public override void Update()
    {
        return;
    }

   
    public override string Render()
    {
        return "";
    }
}

