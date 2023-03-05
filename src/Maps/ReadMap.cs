namespace Dungeon_Crawl.src.Maps;
static class ReadMap
{

    public static string[] ReadFirstFloor()
    {
        var firstMap = File.ReadAllLines(@"..\..\..\src\Maps\map\map1.txt");
        return firstMap;
    }
    public static string[] ReadAreaFight()
    {
        var areaFight = File.ReadAllLines(@"..\..\..\src\Maps\map\areafight.txt");
        return areaFight;
    }
    public static string[] ReadSecondFloor()
    {
        var secondMap = File.ReadAllLines(@"..\..\..\src\Maps\map\map2.txt");
        return secondMap;
    }
    public static string[] ReadBossFloor()
    {
        var bossMap = File.ReadAllLines(@"..\..\..\src\Maps\map\mapBoss.txt");
        return bossMap;
    }
}
    

