using System;
using System.Collections.Generic;
using Monopoly.Board;
using Monopoly.Dice;
using Monopoly.JailRoster;
using Monopoly.Players;

namespace MonopolyTests.Fakes
{
    public class FakeBoard : GameBoard
    {
        public String Turns { get; private set; }
        public Dictionary<Int32, Int32> PlayerTurns { get; private set; }

        public FakeBoard(IDice dice, IPlayerRepository playerRepository, IJailRoster jailRoster)
            : base(playerRepository, new FakeTurnFactory())
        {
            Turns = String.Empty;
            PlayerTurns = new Dictionary<Int32, Int32>();
        }

        protected override void TakeTurnFor(Int32 playerId)
        {
            Turns += playerId;

            try
            {
                PlayerTurns[playerId]++;
            }
            catch (KeyNotFoundException)
            {
                PlayerTurns.Add(playerId, 1);
            }
        }

        public IEnumerable<Int32> GetPlayers()
        {
            return playerIds;
        }
    }
}
