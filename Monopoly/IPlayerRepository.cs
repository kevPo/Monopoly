using System;
using System.Collections.Generic;

namespace Monopoly
{
    public interface IPlayerRepository
    {
        IPlayer GetPlayer(Int32 id);
        void RemovePlayer(Int32 id);
        IEnumerable<IPlayer> GetPlayers();
        void ShufflePlayers();
        void SetAllPlayerLocationsTo(Int32 locationIndex);
    }
}
