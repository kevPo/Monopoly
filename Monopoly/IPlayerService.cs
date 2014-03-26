using System;
namespace Monopoly
{
    public interface IPlayerService
    {
        void AddMoneyTo(Int32 playerId, Int32 money);
        void ChargeTaxesTo(Int32 playerId, Func<Int32, Int32> taxEquation);
        Int32 GetBalanceFor(Int32 playerId);
        Int32 GetLocationIndexFor(Int32 playerId);
        void RemoveMoneyFrom(Int32 playerId, Int32 money);
        void SetLocationIndexFor(Int32 playerId, Int32 locationIndex);
        void TransferMoney(Int32 givingPlayerId, Int32 receivingPlayerId, Int32 money);
    }
}
