using Monopoly.Dice;
using NUnit.Framework;

namespace MonopolyTests.DiceTests
{
    [TestFixture]
    public class TraditionalDiceTests
    {
        private TraditionalDice dice;
        
        [SetUp]
        public void SetUp()
        {
            dice = new TraditionalDice();
        }

        [Test]
        public void TestRollGeneratesRandomNumberBetween2And13()
        {
            dice.Roll();
            var roll = dice.GetCurrentRoll();

            Assert.That(dice.DiceOne, Is.Not.Null);
            Assert.That(dice.DiceTwo, Is.Not.Null);
            Assert.That(roll > 1 && roll < 13, Is.True);
        }

        [Test]
        public void TestDiceIsDouble()
        {
            dice.Roll();
            var expected = dice.DiceOne == dice.DiceTwo;

            Assert.That(dice.RollWasDouble(), Is.EqualTo(expected));
        }
    }
}
