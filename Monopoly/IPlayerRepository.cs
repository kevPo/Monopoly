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
        void SetLocationIndexFor(Int32 playerId, Int32 locationIndex);
        Int32 GetLocationIndexFor(Int32 playerId);
        void RemoveMoneyFrom(Int32 playerId, Int32 money);
        void AddMoneyTo(Int32 playerId, Int32 money);
        void ChargeTaxesTo(Int32 playerId, Func<Int32, Int32> taxEquation);
        void TransferMoney(Int32 givingPlayer, Int32 receivingPlayer, Int32 money);
        void UpdatePlayer(IPlayer player);
        Int32 GetBalanceFor(Int32 playerId);
    }
}
