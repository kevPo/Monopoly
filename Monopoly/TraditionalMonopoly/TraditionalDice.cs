using System;

namespace Monopoly.TraditionalMonopoly
{
    public class TraditionalDice : IDice
    {
        private Int32 currentDiceRoll;
        private Random randomDiceGenerator;

        public TraditionalDice()
        {
            currentDiceRoll = 0;
            randomDiceGenerator = new Random();
        }

        public void Roll()
        {
            currentDiceRoll = randomDiceGenerator.Next(2, 13);
        }

        public Int32 GetCurrentDiceRoll()
        {
            return currentDiceRoll;
        }
    }
}
