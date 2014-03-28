using System;

namespace MonopolyTests.Fakes
{
    public class FakeRoll
    {
        public Int32 Dice1 { get; private set; }
        public Int32 Dice2 { get; private set; }

        public FakeRoll(Int32 dice1, Int32 dice2)
        {
            Dice1 = dice1;
            Dice2 = dice2;
        }

        public Boolean IsDouble()
        {
            return Dice1 == Dice2;
        }

        public Int32 Total()
        {
            return Dice1 + Dice2;
        }
    }
}
