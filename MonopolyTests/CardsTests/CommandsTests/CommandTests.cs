using System;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Cards;
using Monopoly.JailRoster;
using Monopoly.Locations.Factories;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.CardsTests.CommandsTests
{
    public class CommandTests 
    {
        protected TraditionalBanker banker;
        protected GameBoard gameBoard;
        protected TraditionalJailRoster jailRoster;
        protected FakeDice dice;
        protected Int32 playerOneId;
        protected Int32 playerTwoId;
        protected Int32 playerThreeId;
        protected Int32 playerFourId;
        protected Int32 playerFiveId;

        [SetUp]
        public virtual void SetUp()
        {
            playerOneId = 0;
            playerTwoId = 1;
            playerThreeId = 2;
            playerFourId = 3;
            playerFiveId = 4;
            banker = new TraditionalBanker(new[] { playerOneId, playerTwoId, playerThreeId, playerFourId, playerFiveId });
            jailRoster = new TraditionalJailRoster(banker);
            gameBoard = new GameBoard(banker);
            dice = new FakeDice();
            var cardDeckFactory = new TraditionalCardDeckFactory(banker, jailRoster, gameBoard, dice);
            var locationFactory = new TraditionalLocationFactory(banker, dice, jailRoster, gameBoard, cardDeckFactory);
            gameBoard.SetLocations(locationFactory.GetLocations(), locationFactory.GetRailroads(), locationFactory.GetUtilities());
        }
    }
}
