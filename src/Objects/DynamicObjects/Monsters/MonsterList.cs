namespace Dungeon_Crawl.src.Objects.DynamicObjects.Monsters;
internal class MonsterList
    {
        private List<Monster> Monsters;

        public MonsterList(Position position)
        {
            Monsters = new List<Monster>()
            {
                new Archer(position),
                new Warrior(position)
            };
        }

        public Monster RandomMonster()
        {
            var random = new Random();
            var monsterIndex = random.Next(Monsters.Count);
            var monster = Monsters[monsterIndex];
            return monster;
        }
}

