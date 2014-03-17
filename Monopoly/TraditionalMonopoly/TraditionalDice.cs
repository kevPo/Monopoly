using System;

namespace Monopoly.TraditionalMonopoly
{
    public class TraditionalDice : IDice
    {
        private Int32 diceOne;
        private Int32 diceTwo;
        private Random randomDiceGenerator;

        public TraditionalDice()
        {
            diceOne = 0;
            diceTwo = 0;
            randomDiceGenerator = new Random();
        }

        public void Roll()
        {
            diceOne = randomDiceGenerator.Next(1, 7);
            diceTwo = randomDiceGenerator.Next(1, 7);
        }

        public Int32 GetCurrentRoll()
        {
            return diceOne + diceTwo;
        }

        public Boolean RollWasDouble()
        {
            return diceOne == diceTwo;
        }
    }
}
