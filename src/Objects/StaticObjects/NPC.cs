namespace Dungeon_Crawl.src.Objects.StaticObjects;
internal class NPC : StaticObject
{
    private List<string> dialog = new();
    private int currentPhrase = -1;
    public NPC(Position position) : base(position)
    {
        dialog.Add("Hello stranger!");
        dialog.Add("It's too dangerous outside");
        dialog.Add("Be careful");
        dialog.Add("Good luck.");
    }

    public bool Finished { get; private set; }

    public override bool IsPassable => true;

    protected override string Symbol => "N";
    public string GetNextPhrase()
    {
        currentPhrase = Math.Min(++currentPhrase, dialog.Count - 1);
        if (currentPhrase == dialog.Count - 1)
        {
            Finished = true;
        }
        return dialog[currentPhrase];
    }
}

