﻿using System;

namespace Monopoly.Banker
{
    public interface IBanker
    {
        void PayMoneyTo(Int32 playerId, Int32 money);
        void CollectMoneyFrom(Int32 playerId, Int32 money);
        Int32 GetBalanceFor(Int32 playerId);
        void TransferMoney(Int32 givingPlayerId, Int32 receivingPlayerId, Int32 money);
        void ChargeTaxesTo(Int32 playerId, Func<Int32, Int32> taxEquation);
        void CollectMoneyFromAllPlayers(Int32 playerId, Int32 money);
        void PayMoneyToAllPlayers(Int32 playerId, Int32 money);
    }
}
