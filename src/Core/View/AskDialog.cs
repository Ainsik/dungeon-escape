namespace Dungeon_Crawl.src.Core.View;

public class AskDialog
{
    public delegate void SelectedChoiceHandler(bool accepted);

    private const int _width = 50;
    protected readonly Tuple<string, string> choices;
    protected int _selectedChoice = 0;
    private SelectedChoiceHandler? _selectedChoiceHandler;

    public string Text { get; }
    public virtual string Choices
    {
        get
        {
            if (_selectedChoice == 0)
            {
                return $"<{choices.Item1}> {choices.Item2}";
            }
            else
            {
                return $"{choices.Item1} <{choices.Item2}>";
            }
        }
    }

    public virtual void SelectLeft() => _selectedChoice = 0;
    public virtual void SelectRight() => _selectedChoice = 1;
    public bool Accepted { get; private set; }
    public bool Resolved { get; private set; }

    internal void Select()
    {
        Resolved = true;
        Accepted = _selectedChoice == 0;
        _selectedChoiceHandler?.Invoke(Accepted);
    }

    public AskDialog(string text, Tuple<string, string> choices, SelectedChoiceHandler? handler)
    {
        Text = text;
        this.choices = choices;
        _selectedChoiceHandler = handler;
    }
}