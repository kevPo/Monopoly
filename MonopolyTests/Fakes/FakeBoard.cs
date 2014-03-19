using System;
using System.Collections.Generic;
using Monopoly;
using Monopoly.Board;

namespace MonopolyTests.Fakes
{
    public class FakeBoard : GameBoard
    {
        public String Turns { get; private set; }
        public Dictionary<IPlayer, Int32> PlayerTurns { get; private set; }

        public FakeBoard(IDice dice, IJailRoster jailRoster)
            : base(dice, jailRoster)
        {
            Turns = String.Empty;
            PlayerTurns = new Dictionary<IPlayer, Int32>();
        }

        public override void TakeTurnFor(IPlayer player)
        {
            Turns += player.Name;

            try
            {
                PlayerTurns[player]++;
            }
            catch (KeyNotFoundException)
            {
                PlayerTurns.Add(player, 1);
            }
        }
    }
}
