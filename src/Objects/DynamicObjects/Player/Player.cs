namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player;

public class Player : DynamicObject
{
    private readonly KeyboardController _keyboardController = new();
    private readonly Movement movementController;
    private readonly Map map;
    private readonly ItemController itemController;
    private readonly NPCdialog NPCdialog;
    private readonly MonsterDialog monsterDialog;
    private readonly DoorController doorController;


    public Player(Position position, Movement movementController, Map map) : base(position)
    {
        Stats = new Stats
        {
            HealthPoints = 100,
            Strength = 15,
            Defense = 5
        };
        Level = new LevelUp();
        Inventory = new Inventory(this);
        this.movementController = movementController;
        this.map = map;
        itemController = new(map, this);
        NPCdialog = new(map, this);
        monsterDialog = new(map, this);
        doorController = new(map, this);
    }

    protected override string Symbol => "P";
    public Inventory Inventory { get; internal set; }
    public Stats Stats { get; set; }
    public LevelUp Level { get; set; }
    public AskDialog? Info { get; internal set; }

    public State ProcessInput(ConsoleKey key, State currentState)
    {
        switch (currentState)
        {
            case State.Game:
                if (Info is not null)
                {
                    return State.Info;
                }
                switch (key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.S:
                    case ConsoleKey.A:
                    case ConsoleKey.D:
                        if (itemController.PickItem() is State.Info) return State.Info;
                        if (NPCdialog.PickItem() is State.Info) return State.Info;
                        if (monsterDialog.PickItem() is State.Info) return State.Fight;
                        if (doorController.PickItem() is State.Info) return State.Info;
                        MakeMove(key, movementController);
                        return State.Game;
                    case ConsoleKey.I:
                        return State.Inventory;
                    default:
                        return State.Game;
                }
            case State.Pause:
                break;
            case State.Inventory:
                switch (key)
                {
                    case ConsoleKey.W:
                        Inventory.SelectPrevious();
                        return State.Inventory;
                    case ConsoleKey.S:
                        Inventory.SelectNext();
                        return State.Inventory;
                    case ConsoleKey.Enter:
                        return Inventory.UseItem();
                    default:
                        return State.Game;
                }
            case State.Info:
                if (Info is null)
                    return State.Game;
                switch (key)
                {
                    case ConsoleKey.D:
                        Info.SelectRight();
                        return State.Info;
                    case ConsoleKey.A:
                        Info.SelectLeft();
                        return State.Info;
                    case ConsoleKey.Enter:
                        Info.Select();
                        Info = null;
                        return State.Game;
                    default:
                        Info = null;
                        return State.Game;
                }
            case State.Fight:
                break;
        }
        return State.Game;
    }

    private void MakeMove(ConsoleKey key, Movement movementController)
    {
        var newPosition = KeyboardController.HandleMovement(key, Position);
        var MoveWasSuccessfull = movementController.Move(Position, newPosition);
        if (MoveWasSuccessfull)
        {
            Position = newPosition;
        }
    }

    public override string Render()
    {
        return Symbol;
    }

    public override void Update()
    {

    }

}

