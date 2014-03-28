using System;
using Monopoly;
using Monopoly.Turns;

namespace MonopolyTests.Fakes
{
    public class FakeTurnFactory : ITurnFactory
    {
        public Turn GetTurnFor(Int32 playerId)
        {
            throw new NotImplementedException();
        }
    }
}
