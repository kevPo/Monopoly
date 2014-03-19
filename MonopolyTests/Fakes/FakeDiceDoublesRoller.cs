using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly;

namespace MonopolyTests.Fakes
{
    public class FakeDiceDoublesRoller : IDice
    {
        private Int32 rollBeforeDoubles;
        private Int32[] doubleRolls;
        private Int32 nextRollAfterDouble;
        private Int32 diceRolledCount;
        private List<Int32> rolls;
        private Int32 doubleRollStartingIndex;

        public FakeDiceDoublesRoller(Int32[] doubleRolls, Int32 nextRollAfterDouble)
            : this(0, doubleRolls, nextRollAfterDouble)
        { }

        public FakeDiceDoublesRoller(Int32 rollBeforeDoubles, Int32[] doubleRolls, Int32 nextRollAfterDouble)
        {
            this.rollBeforeDoubles = rollBeforeDoubles;
            this.doubleRolls = doubleRolls;
            this.nextRollAfterDouble = nextRollAfterDouble;
            diceRolledCount = 0;
            InitializeRolls();
        }

        private void InitializeRolls()
        {
            rolls = new List<Int32>();

            if (rollBeforeDoubles != 0)
            {
                rolls.Add(rollBeforeDoubles);
                doubleRollStartingIndex = 1;
            }
            else
            {
                doubleRollStartingIndex = 0;
            }

            foreach (var roll in doubleRolls)
                rolls.Add(roll);

            rolls.Add(nextRollAfterDouble);
        }

        public void Roll()
        {
            diceRolledCount++;
        }

        public Int32 GetCurrentRoll()
        {
            return rolls[diceRolledCount - 1];
        }

        public Boolean RollWasDouble()
        {
            return diceRolledCount <= doubleRolls.Count() + doubleRollStartingIndex && 
                diceRolledCount >= doubleRollStartingIndex ;
        }
    }
}
