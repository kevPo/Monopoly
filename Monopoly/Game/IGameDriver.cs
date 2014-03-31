using System;
using System.Collections.Generic;
namespace Monopoly.Game
{
    public interface IGameDriver
    {
        void PlayGameWith(IEnumerable<String> tokens);
    }
}
