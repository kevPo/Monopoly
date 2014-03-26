using System;
using System.Collections.Generic;
namespace Monopoly.TraditionalMonopoly
{
    public interface IGameDriver
    {
        void PlayGameWith(IEnumerable<String> tokens);
    }
}
