﻿namespace Dungeon_Crawl.src.Monsters;

internal class Warrior : Monster
{
    public Warrior(Position position) : base(position)
    {
    }

    protected override string Symbol { get => "W"; set => throw new NotImplementedException(); }

    public override void Update()
    {
        return;
    }

    public override string Render()
    {
        return "";
    }
}

