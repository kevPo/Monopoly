using System;
using System.Collections.Generic;

namespace Monopoly
{
    public interface IPlayerRepository
    {
        IPlayer GetPlayer(Guid id);
        void RemovePlayer(Guid id);
        IEnumerable<IPlayer> GetPlayers();
        void ShufflePlayers();
    }
}
