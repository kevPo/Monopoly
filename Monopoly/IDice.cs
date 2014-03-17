using System;

namespace Monopoly
{
    public interface IDice
    {
        void Roll();
        Int32 GetCurrentRoll();
        Boolean RollWasDouble();
    }
}
