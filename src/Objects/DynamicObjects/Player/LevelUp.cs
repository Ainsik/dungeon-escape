namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player;

public class LevelUp
{
    public int maxHealtPoints;
    public int level;
    public int experience;
    public int experienceRequired;

    public LevelUp()
    {
        maxHealtPoints = 100;
        level = 1;
        experience = 0;
        experienceRequired = 100;
    }

    public void IncreaseLevel(Player player)
    {
        level += 1;
        experience = 0;
        maxHealtPoints += 20;
        player.Stats.Defense += 2;
        player.Stats.Strength += 2;
        player.Stats.HealthPoints = maxHealtPoints;
        experienceRequired += 100;
        player.Info = new InfoDialog($"New level {level}!", "Ok", null);
    }
    public void Update(Player player)
    {
        if (experience >= experienceRequired)
            IncreaseLevel(player);
    }


}
