using System;
using System.Collections.Generic;
namespace Monopoly.GameDriver
{
    public interface IGameDriver
    {
        void PlayGameWith(IEnumerable<String> tokens);
    }
}
