namespace Dungeon_Crawl.src.Core.View
{
    internal class SidebarDirector
    {
        private readonly Sidebar _sidebar = new();
        private readonly ProgressBar _progressBar = new();

        public List<string> MakeInfobar(Stats stats, Inventory inventory, int height, LevelUp level)
        {
            GeneratePlayerStats(stats, level);
            _sidebar.AddHorizontalRule();
            GenerateInventoryView(inventory);
            _sidebar.AddHorizontalRule();

            var equipment = inventory.Equipment;
            GenerateEquipmentView(equipment);
            return _sidebar.CreateFrame(height);
        }

        private void GeneratePlayerStats(Stats stats, LevelUp level)
        {
            _sidebar.AddCenteredText("Stats");
            GenerateLevel(level);
            GenerateHp(stats, level.maxHealtPoints);
            GenerateStatsView(stats);
        }

        private void GenerateInventoryView(Inventory inventory)
        {
            _sidebar.AddCenteredText("Inventory");
            var inventoryItems = inventory.GetItems();
            var showFromIndex = Math.Max(inventory.SelectedItemIndex - 4, 0);
            for (var i = showFromIndex; i < showFromIndex + 5; i++)
            {
                if (i < inventoryItems.Count)
                {
                    var item = inventoryItems[i];
                    if (i == inventory.SelectedItemIndex)
                    {
                        _sidebar.AddLeftAlignedText($"> {item.Name}");
                    }
                    else
                    {
                        _sidebar.AddLeftAlignedText($" {item.Name}");
                    }
                }
                else
                {
                    _sidebar.AddCenteredText("");
                }
            }
        }

        private void GenerateLevel(LevelUp level)
        {
                _sidebar.AddLeftAlignedText($" Level: {level.level}");;
                _sidebar.AddLeftAlignedText($" Experience: {level.experience}/{level.experienceRequired}");
                _sidebar.AddLeftAlignedText(_progressBar.DrawBar(level.experience,level.experienceRequired));
        }
        private void GenerateHp(Stats stats, int maxHP)
        {
            _sidebar.AddLeftAlignedText($" Health: {stats.HealthPoints}/{maxHP}");
            _sidebar.AddLeftAlignedText(_progressBar.DrawBar(stats.HealthPoints, maxHP));
        }
        private void GenerateStatsView(Stats stats)
        {
            _sidebar.AddLeftAlignedText($" Strength: {stats.Strength}");
            _sidebar.AddLeftAlignedText($" Defense: {stats.Defense}");
        }

        private void GenerateEquipmentView(Equipment equipment)
        {
            _sidebar.AddCenteredText("Equipment");
            _sidebar.AddLeftAlignedText($" Head: {(equipment.Helmet is null ? "Nothing" : equipment.Helmet.Name)}");
            _sidebar.AddLeftAlignedText($" Body: {(equipment.Cuirass is null ? "Nothing" : equipment.Cuirass.Name)}");
            _sidebar.AddLeftAlignedText($" Hands: {(equipment.Gloves is null ? "Nothing" : equipment.Gloves.Name)}");
            _sidebar.AddLeftAlignedText($" Legs: {(equipment.Greaves is null ? "Nothing" : equipment.Greaves.Name)}");
            _sidebar.AddLeftAlignedText($" Foots: {(equipment.Boots is null ? "Nothing" : equipment.Boots.Name)}");
            _sidebar.AddLeftAlignedText($" Weapon: {(equipment.Weapon is null ? "Nothing" : equipment.Weapon.Name)}");
        }

        public List<string> MakeInfoBox(AskDialog info, int height = 5)
        {
            _sidebar.AddCenteredText(info.Text);
            _sidebar.AddEmptyLine();
            _sidebar.AddCenteredText(info.Choices);
            return _sidebar.CreateFrame(height);
        }
        public List<string> MakeInfobarFight(Stats stats, Stats monsterStats, int height, LevelUp level, int maxMonsterHp)
        {
            _sidebar.AddCenteredText("Monster stats");
            GenerateHp(monsterStats, maxMonsterHp);
            GenerateStatsView(monsterStats);
            _sidebar.AddHorizontalRule();
            GeneratePlayerStats(stats, level);
            return _sidebar.CreateFrame(height);
        }
    }
}
