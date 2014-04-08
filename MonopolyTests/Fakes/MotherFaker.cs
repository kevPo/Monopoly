using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Cards;
using Monopoly.JailRoster;
using Monopoly.Locations.Factories;

namespace MonopolyTests.Fakes
{
    public class MotherFaker
    {
        public FakeDice Dice { get; private set; }
        public TraditionalBanker Banker { get; private set; }
        public TraditionalJailRoster JailRoster { get; private set; }
        public GameBoard GameBoard { get; private set; }
        public LocationFactory LocationFactory { get; private set; }

        public MotherFaker()
        {
            Dice = new FakeDice();
            Banker = new TraditionalBanker(new[] { 0 });
            JailRoster = new TraditionalJailRoster(Banker);
            GameBoard = new GameBoard(Banker);
            var cardDeckFactory = new TraditionalCardDeckFactory(Banker, JailRoster, GameBoard, Dice);
            LocationFactory = new TraditionalLocationFactory(Banker, Dice, JailRoster, GameBoard, cardDeckFactory);
            GameBoard.SetLocations(LocationFactory.GetLocations(), LocationFactory.GetRailroads(), LocationFactory.GetUtilities());
        }
    }
}
