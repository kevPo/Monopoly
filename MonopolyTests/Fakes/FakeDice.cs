using System;
using Monopoly;

namespace MonopolyTests.Fakes
{
    public class FakeDice : IDice
    {
        public Int32 NextRoll { get; set; }

        public void Roll()
        {}

        public Int32 GetCurrentRoll()
        {
            return NextRoll;
        }

        public Boolean RollWasDouble()
        {
            return false;
        }
    }
}
