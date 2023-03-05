namespace Dungeon_Crawl.src.Actions;

internal class Fight
{
    private int counter = 0;
    private readonly Camera _camera;
    private readonly SidebarDirector _sidebarDirector;
    private readonly Display _display;
    private FightArea _fightArea;
    public Position Position { get; set; }

    public Fight()
    {
        _fightArea = new FightArea();
        _camera = new Camera();
        _display = new Display();
        _sidebarDirector = new SidebarDirector();
    }

    public void PlayerTurn(Player player, Monster monster)
    {
        _fightArea.AddObject(player.Position, player);
        _fightArea.AddObject(monster.Position, monster);
        {
            UpdateAreaFight(player, monster);
            if (player.Position.Y - monster.Position.Y > 1)
                GoToMonster(player);
            else
            {
                if ((player.Level.level > 1) && (counter > 1))
                    FightWithLevelOverOne(player, monster);
                else
                    FightWithLevelOne(player, monster);
            }
        }
    }

    private void FightWithLevelOne(Player player, Monster monster)
    {
        bool condition = false;
        while (!condition)
        {
            Console.Write("\t\t\t\t");
            string options = Console.ReadLine();
            switch (options)
            {
                case "1":
                    PlayerAttack(player, monster);
                    condition = true;
                    break;
                case "2":
                    HealPlayer(player);
                    Console.WriteLine("\t\t\t\tNo implemented yet");
                    condition = false;
                    break;
                default:
                    Console.WriteLine("\t\t\t\tValid choice. Choose 1 or 2");
                    break;
            }
        }
    }

    private void FightWithLevelOverOne(Player player, Monster monster)
    {
        bool condition = false;
        while (!condition)
        {
            Console.Write("\t\t\t\t");
            string options = Console.ReadLine();
            switch (options)
            {
                case "1":
                    PlayerAttack(player, monster);
                    condition = true;
                    break;
                case "2":
                    HealPlayer(player);
                    Console.WriteLine("\t\t\t\tNo implemented yet");
                    condition = false;
                    break;
                case "3":
                    PlayerAttackCritical(player, monster);
                    condition = true;
                    break;
                default:
                    Console.WriteLine("\t\t\t\tValid choice. Choose 1, 2 or 3");
                    break;
            }
        }
    }

    private void GoToMonster(Player player)
    {
        bool condition = false;
        while (!condition)
        {
            Console.Write("\t\t\t\t");
            string options = Console.ReadLine();
            switch (options)
            {
                case "1":
                    ChangePosition(player);
                    condition = true;
                    break;
                case "2":
                    HealPlayer(player);
                    Console.WriteLine("\t\t\t\tNo implemented yet");
                    condition = false;
                    break;
                default:
                    Console.WriteLine("\t\t\t\tValid choice. Choose 1 or 2");
                    break;
            }
        }
    }

    private void UpdateAreaFight(Player player, Monster monster)
    {
        Console.Clear();
        var view = _camera.GetView(_fightArea);
        var monsterInfo = _sidebarDirector;
        var inventoryView = _sidebarDirector.MakeInfobarFight(player.Stats, monster.Stats, view.Count(), player.Level, monster.maxMonsterHP);
        _display.DisplayView(view, inventoryView);
        _display.DisplayOptionsFight(player.Position.Y, monster.Position.Y, player.Level.level, counter);
    }

    public void ChangePosition(Player player)
    {
        int a = player.Position.Y - 1;
        var oldPlayerPosition = new Position(player.Position.X, player.Position.Y);
        var newPlayerPosition = new Position(player.Position.X, a);
        player.Position = newPlayerPosition;
        _fightArea.ChangePositions(newPlayerPosition, oldPlayerPosition);
    }
    public void HealPlayer(Player player)
    {

    }
    public bool FightRound(Player player, Monster monster)
    {
        while (player.Stats.HealthPoints > 0 && monster.Stats.HealthPoints > 0)
        {
            PlayerTurn(player, monster);
            MonsterTurn(player, monster);
            counter += 1;
        }
        _fightArea.DeletePositions(player.Position);
        if (player.Stats.HealthPoints > 0)
        {
            player.Level.experience += monster.experienceToGain;
            player.Level.Update(player);
            return true;
        }
        else
            return false;

    }
    public void PlayerAttack(Player player, Monster monster)
    {
        int attackPlayer = player.Stats.Strength;
        int defenceMonster = monster.Stats.Defense;
        monster.Stats.HealthPoints = monster.Stats.HealthPoints - (attackPlayer - defenceMonster);

    }
    public void PlayerAttackCritical(Player player, Monster monster)
    {
        int attackPlayer = player.Stats.Strength;
        int defenceMonster = monster.Stats.Defense;
        int attackMultiplier = 2;
        monster.Stats.HealthPoints = monster.Stats.HealthPoints - (attackMultiplier * attackPlayer - defenceMonster);
        counter = 0;
    }
    public void MonsterTurn(Player player, Monster monster)
    {
        UpdateAreaFight(player, monster);
        if (monster is Archer)
            AttackArcher(player, monster);
        else if (monster is Warrior)
            AttackWarrior(player, monster);
    }

    private static void AttackWarrior(Player player, Monster monster)
    {
        if (player.Position.Y - monster.Position.Y == 1)
        {
            int attackMonster = monster.Stats.Strength;
            int defencePlayer = player.Stats.Defense;
            if (attackMonster <= defencePlayer)
            {
                player.Stats.HealthPoints -= 1;
            }
            else
            {
                player.Stats.HealthPoints = player.Stats.HealthPoints - (attackMonster - defencePlayer);
            }
        }
    }

    private static void AttackArcher(Player player, Monster monster)
    {
        int attackMonster = monster.Stats.Strength;
        int defencePlayer = player.Stats.Defense;
        if (attackMonster <= defencePlayer)
        {
            player.Stats.HealthPoints -= 1;
        }
        else
        {
            player.Stats.HealthPoints = player.Stats.HealthPoints - (attackMonster - defencePlayer);
        }
    }
}