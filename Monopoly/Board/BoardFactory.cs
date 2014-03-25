using System;
using System.Collections.Generic;
using Monopoly.Locations;
namespace Monopoly.Board
{
    public abstract class BoardFactory
    {
        protected IBoard board;
        protected IDice dice;
        protected IEnumerable<IPlayer> players;
        protected IJailRoster jailRoster;

        public BoardFactory(IDice dice, IEnumerable<IPlayer> players, IJailRoster jailRoster)
        {
            this.dice = dice;
            this.players = players;
            this.jailRoster = jailRoster;
        }

        public IBoard GetBoard()
        {
            return new GameBoard(dice, jailRoster, players, GetLocations());            
        }

        protected abstract IEnumerable<Location> GetLocations();
        protected abstract Int32 LuxuryTaxEquation(Int32 balance);
        protected abstract Int32 IncomeTaxEquation(Int32 balance);
    }
}
