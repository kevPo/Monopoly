using Monopoly.Board;

namespace MonopolyTests.Fakes
{
    public class FakeBoardFactory : BoardFactory
    {
        public FakeBoardFactory(FakeBoard board)
        {
            Board = board;
        }

        protected override void CreateBank()
        {}

        protected override void CreatePropertyGroups()
        {}

        protected override void CreateCardDraws()
        {}

        protected override void CreateTaxables()
        {}

        protected override void CreateJailRelated()
        {}

        protected override void CreateGo()
        {}

        protected override void CreateFreeParking()
        {}
    }
}
