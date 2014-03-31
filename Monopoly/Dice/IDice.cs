using System;

namespace Monopoly.Dice
{
    public interface IDice
    {
        void Roll();
        Int32 GetCurrentRoll();
        Boolean RollWasDouble();
    }
}
