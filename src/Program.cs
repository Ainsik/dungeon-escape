namespace Dungeon_Crawl.src;

public class Program
{

    public static void Main(string[] args)
    {
        var menu = new Menu();
        menu.PrintMenu();
        menu.ChoiceFromMenu(Console.ReadKey().Key);
        var game = new Game();
        game.Start();
    }
}