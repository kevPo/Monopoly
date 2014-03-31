using System;
using System.Collections.Generic;

namespace Monopoly.Players
{
    public interface IPlayerRepository
    {
        IPlayer GetPlayer(Int32 id);
        void RemovePlayer(Int32 id);
        IEnumerable<Int32> GetPlayerIds();
        void ShufflePlayers();
    }
}
