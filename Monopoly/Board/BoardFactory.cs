﻿using System;
using System.Collections.Generic;
using Monopoly.Locations;
namespace Monopoly.Board
{
    public abstract class BoardFactory
    {
        protected IBoard board;
        protected IDice dice;
        protected IPlayerRepository playerRepository;
        protected IJailRoster jailRoster;

        public BoardFactory(IDice dice, IPlayerRepository playerRepository, IJailRoster jailRoster)
        {
            this.dice = dice;
            this.playerRepository = playerRepository;
            this.jailRoster = jailRoster;
        }

        public IBoard GetBoard()
        {
            var turn = new Turn(GetLocations(), jailRoster, new PlayerService(playerRepository), dice);
            return new GameBoard(playerRepository, turn);            
        }

        protected abstract IEnumerable<Location> GetLocations();
        protected abstract Int32 LuxuryTaxEquation(Int32 balance);
        protected abstract Int32 IncomeTaxEquation(Int32 balance);
    }
}
