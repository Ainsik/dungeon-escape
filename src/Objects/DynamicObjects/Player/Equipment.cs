using System.Diagnostics;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{

    public enum EquipmentType
    {
        Helmet,
        Cuirass,
        Gloves,
        Greaves,
        Boots,
        Weapon
    }
    internal class Equipment
    {
        private readonly Inventory _inventory;
        private readonly Player _player;
        private readonly Armor[] _equippedItems = new Armor[6];

        public Armor? Helmet { get => GetEquippedItem(EquipmentType.Helmet); }
        public Armor? Cuirass { get => GetEquippedItem(EquipmentType.Cuirass); }
        public Armor? Gloves { get => GetEquippedItem(EquipmentType.Gloves); }
        public Armor? Greaves { get => GetEquippedItem(EquipmentType.Greaves); }
        public Armor? Boots { get => GetEquippedItem(EquipmentType.Boots); }
        public Armor? Weapon { get => GetEquippedItem(EquipmentType.Weapon); }

        public Equipment(Inventory inventory, Player player)
        {
            _inventory = inventory;
            _player = player;
        }

        public void Equip(Armor? equipment)
        {
            Debug.Assert(equipment is not null);
            
            _inventory.RemoveItem(equipment);

            var equippedItem = _equippedItems[(int) equipment.equipmentType];
            if (equippedItem is not null)
            {
                _player.Stats.UpdateStats(-equippedItem.Stats.HealthPoints, -equippedItem.Stats.Strength, -equippedItem.Stats.Defense);
                _inventory.AddItem(equippedItem);
            }

            _equippedItems[(int) equipment.equipmentType] = equipment;
            _player.Stats.UpdateStats(equipment.Stats.HealthPoints, equipment.Stats.Strength, equipment.Stats.Defense);
        }
        private Armor? GetEquippedItem(EquipmentType equipmentType)
        {
            return _equippedItems[(int) equipmentType];
        }
    }
}