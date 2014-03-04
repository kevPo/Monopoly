using Monopoly;
using Monopoly.Assessors;
using NUnit.Framework;

namespace MonopolyTests.AssessorsTests
{
    [TestFixture]
    public class IncomeTaxAssessorTests
    {
        private Board board;
        private IncomeTaxAssessor incomeTax;

        [SetUp]
        public void SetUp()
        {
            board = new Board();
            incomeTax = new IncomeTaxAssessor();
        }

        [Test]
        public void TestIncomeTaxCharges10PercentIfBalanceLessThan2000()
        {
            var player = new Player("Horse", 1800, board);
            incomeTax.HandleLocationStopFor(player);
            Assert.That(player.Balance, Is.EqualTo(1620));
        }

        [Test]
        public void TestIncomeTaxCharges200IfBalanceGreaterThan2000()
        {
            var player = new Player("Horse", 2200, board);
            incomeTax.HandleLocationStopFor(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestIncomeTaxChargesNothingWhenBalanceIsZero()
        {
            var player = new Player("Horse", 0, board);
            incomeTax.HandleLocationStopFor(player);
            Assert.That(player.Balance, Is.EqualTo(0));
        }

        [Test]
        public void TestIncomeTaxCharges200WhenBalanceIs2000()
        {
            var player = new Player("Horse", 2000, board);
            incomeTax.HandleLocationStopFor(player);
            Assert.That(player.Balance, Is.EqualTo(1800));
        }
    }
}
