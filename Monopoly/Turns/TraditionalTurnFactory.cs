using System;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Cards;
using Monopoly.Dice;
using Monopoly.JailRoster;
using Monopoly.Locations.Factories;

namespace Monopoly.Turns
{
    public class TraditionalTurnFactory : ITurnFactory
    {
        private TraditionalBanker banker;
        private TraditionalDice dice;
        private TraditionalJailRoster jailRoster;
        private GameBoard board;

        public TraditionalTurnFactory(TraditionalBanker banker)
        {
            this.banker = banker;
            board = CreateBoard();
        }

        private GameBoard CreateBoard()
        {
            var gameBoard = new GameBoard(banker);
            dice = new TraditionalDice();
            jailRoster = new TraditionalJailRoster(banker);
            var traditionalCardDeckFactory = new TraditionalCardDeckFactory(banker, jailRoster, gameBoard, dice);
            var locationFactory = new TraditionalLocationFactory(banker, dice, jailRoster, gameBoard, traditionalCardDeckFactory);
            
            gameBoard.SetLocations(locationFactory.GetLocations(), locationFactory.GetRailroads(), locationFactory.GetUtilities());
            
            return gameBoard;
        }

        public Turn GetTurnFor(Int32 playerId)
        {
            if (jailRoster.IsInJail(playerId))
                return new InmateTurn(playerId, dice, jailRoster, board);
            else
                return new NormalTurn(playerId, dice, jailRoster, board);
        }
    }
}
