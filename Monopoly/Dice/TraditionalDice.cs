using System;

namespace Monopoly.Dice
{
    public class TraditionalDice : IDice
    {
        public Int32 DiceOne { get; private set; }
        public Int32 DiceTwo { get; private set; }
        private Random randomDiceGenerator;

        public TraditionalDice()
        {
            DiceOne = 0;
            DiceTwo = 0;
            randomDiceGenerator = new Random();
        }

        public void Roll()
        {
            DiceOne = randomDiceGenerator.Next(1, 7);
            DiceTwo = randomDiceGenerator.Next(1, 7);
        }

        public Int32 GetCurrentRoll()
        {
            return DiceOne + DiceTwo;
        }

        public Boolean RollWasDouble()
        {
            return DiceOne == DiceTwo;
        }
    }
}
