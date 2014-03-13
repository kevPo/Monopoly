using Monopoly.Board;

namespace MonopolyTests.Fakes
{
    public class FakeBoardBuilder : BoardBuilder
    {
        public FakeBoardBuilder(FakeBoard board)
        {
            Board = board;
        }

        public override void BuildBank()
        {}

        public override void BuildPropertyGroups()
        {}

        public override void BuildCardDraws()
        {}

        public override void BuildTaxables()
        {}

        public override void BuildJailRelated()
        {}

        public override void BuildGo()
        {}

        public override void BuildFreeParking()
        {}
    }
}
