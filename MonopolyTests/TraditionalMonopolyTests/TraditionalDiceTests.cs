using Monopoly.TraditionalMonopoly;
using NUnit.Framework;

namespace MonopolyTests.TraditionalMonopolyTests
{
    [TestFixture]
    public class TraditionalDiceTests
    {
        [Test]
        public void TestRollGeneratesRandomNumberBetween2And13()
        {
            var dice = new TraditionalDice();
            dice.Roll();
            var roll = dice.GetCurrentRoll();
            Assert.That(roll > 1 && roll < 13, Is.True);
        }
    }
}
