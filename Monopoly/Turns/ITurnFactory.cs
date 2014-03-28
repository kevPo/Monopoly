using System;

namespace Monopoly.Turns
{
    public interface ITurnFactory
    {
        Turn GetTurnFor(Int32 playerId);
    }
}
