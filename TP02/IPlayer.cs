using System;

namespace TP02
{
    public interface IPlayer
    {
        Spaceship BattleShip { get; set; }
        string Name { get; }
        string Alias { get; }
    }
}