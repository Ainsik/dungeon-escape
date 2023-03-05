namespace Dungeon_Crawl.src.Objects.DynamicObjects;

public class Stats
{
    public int HealthPoints { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }

    public void UpdateStats(int healthPoints, int strength, int defense)
    {
        HealthPoints += healthPoints;
        Strength += strength;
        Defense += defense;
    }
}
