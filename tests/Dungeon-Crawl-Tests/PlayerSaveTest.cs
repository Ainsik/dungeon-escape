using Dungeon_Crawl.src.Actions;
using Dungeon_Crawl.src.Core;
using Dungeon_Crawl.src.Manager;
using Dungeon_Crawl.src.Objects;
using Dungeon_Crawl.src.Objects.DynamicObjects;
using Dungeon_Crawl.src.Objects.DynamicObjects.Player;

namespace Dungeon_Crawl_Tests;

[TestFixture]
public class PlayerSaveTest
{
    private IPlayerDao _playerDao;

    [SetUp]
    public void SetUp()
    {
        var dbManager = new DbManager();
        _playerDao = new PlayerDao("Server=localhost;Database=dungeoun-crawl;Trusted_Connection=True;");
    }
    [Test]
    public void TestLevelSerialization()
    {
        var expectedLevel = new LevelUp();
        expectedLevel.experience = 999;

        var serializedLevel = _playerDao.SerializeToXml(expectedLevel);
        var actualLevel = _playerDao.XmlDeserializeFromString<LevelUp>(serializedLevel);

        Assert.That(actualLevel.experience, Is.EqualTo(expectedLevel.experience));
    }
    [Test]
    public void TestPositionSerialization()
    {
        var expectedPosition = new Position(1, 2);

        var serializedPosition = _playerDao.SerializeToXml(expectedPosition);
        var actualPosition = _playerDao.XmlDeserializeFromString<Position>(serializedPosition);

        Assert.That(actualPosition.X, Is.EqualTo(expectedPosition.X));
        Assert.That(actualPosition.Y, Is.EqualTo(expectedPosition.Y));
    }
    [Test]
    public void TestSavePlayerStats()
    {
        var expectedStats = new Stats();

        expectedStats.Strength = 12;
        expectedStats.HealthPoints = 24;
        expectedStats.Defense = 36;

        var player = new Player(new Position(1, 1), new Movement(new Map()), new Map());
        player.Stats = expectedStats;

        _playerDao.Add(player);
        var savedPlayer = _playerDao.Get(new Map());
        var actualStats = savedPlayer.Stats;

        Assert.That(actualStats.Defense, Is.EqualTo(expectedStats.Defense));
        Assert.That(actualStats.HealthPoints, Is.EqualTo(expectedStats.HealthPoints));
        Assert.That(actualStats.Strength, Is.EqualTo(expectedStats.Strength));

    }
    [Test]
    public void TestSavePlayerPosition()
    {

        var expectedPosition = new Position(1, 2);
        var player = new Player(expectedPosition, new Movement(new Map()), new Map());

        _playerDao.Add(player);
        var savedPlayer = _playerDao.Get(new Map());
        var actualPosition = savedPlayer.Position;

        Assert.That(actualPosition.X, Is.EqualTo(expectedPosition.X));
        Assert.That(actualPosition.Y, Is.EqualTo(expectedPosition.Y));
    }
    [Test]
    public void TestSavePlayerLevel()
    {
        var player = new Player(new Position(1, 2), new Movement(new Map()), new Map());
        var expectedLevel = player.Level;
        expectedLevel.experience = 999;
        player.Level = expectedLevel;

        _playerDao.Add(player);
        var savedPlayer = _playerDao.Get(new Map());
        var actualLevel = savedPlayer.Level;
        Assert.That(actualLevel.experience, Is.EqualTo(expectedLevel.experience));
    }
}