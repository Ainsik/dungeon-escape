namespace Dungeon_Crawl.src.Core
{
    internal class Game
    {
        private Fight _fight;
        private Map _map;
        private readonly Camera _camera;
        public Player _player;
        private readonly Display _display;
        private readonly Movement _movement;
        private readonly SidebarDirector _sidebarDirector;
        private State _currentState;
        private Monster _monster;
        private AskDialog? _pendingInfo;

        public Game()
        {
            _fight = new Fight();
            _currentState = State.Game;
            _map = new Map();
            _player = new Player(new Position(77, 34), new Movement(_map), _map);
            _map.AddObject(_player.Position, _player);
            _movement = new Movement(_map);
            _camera = new Camera();
            _display = new Display();
            _sidebarDirector = new SidebarDirector();
        }
        public void Start()
        {
            Gameloop();
        }
        private void Gameloop()
        {
            while (true)
            {
                Render();
                ProcessInput();
                if (_currentState == State.Game)
                    Update();
                if (_currentState == State.Info)
                {
                    _pendingInfo = _player.Info;
                }
            }
        }

        private void Update()
        {

        }

        private void ProcessInput()
        {
            var key = Console.ReadKey().Key;
            _currentState = _player.ProcessInput(key, _currentState);
        }

        private void Render()
        {
            Console.Clear();
            switch (_currentState)
            {
                case State.Game:
                case State.Inventory:
                    {
                        var view = _camera.GetView(_player.Position, _map);
                        var inventoryView = _sidebarDirector.MakeInfobar(_player.Stats, _player.Inventory, view.Count(), _player.Level);
                        _display.DisplayView(view, inventoryView);
                    }
                    break;
                case State.Pause:
                    break;
                case State.Fight:
                    {
                        int oldPositionX = _player.Position.X;
                        int oldPositionY = _player.Position.Y;
                        string monsterString = _map.SearchMonster(oldPositionX,oldPositionY);
                        if (monsterString == "A")
                        {
                            _monster = new Archer(new Position(38, 3));
                        }
                        else if (monsterString == "W")
                        {
                            _monster = new Warrior(new Position(38, 3));
                        }
                        _player.Position = new Position(38, 7);
                        bool win =_fight.FightRound(_player, _monster);
                        if (win)
                        {
                            _player.Position = new Position(oldPositionX, oldPositionY);
                            _map.DeleteMonster(_player.Position);
                            _currentState = State.Game;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("GAME OVER");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        break;
                    }
                case State.Info:
                    {
                        if (_pendingInfo is null)
                        {
                            throw new Exception("Info should not be null");
                        }
                        var view = _camera.GetView(_player.Position, _map);
                        var inventoryView = _sidebarDirector.MakeInfobar(_player.Stats, _player.Inventory, view.Count(), _player.Level);
                        var infoBox = _sidebarDirector.MakeInfoBox(_pendingInfo);
                        _display.DisplayInfo(view, inventoryView, infoBox);
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
