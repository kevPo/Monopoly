using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly;

namespace MonopolyTests.Fakes
{
    public class FakePlayerRepository : IPlayerRepository
    {
        public IPlayer GetPlayer(Int32 id)
        {
            throw new NotImplementedException();
        }

        public void RemovePlayer(Int32 id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPlayer> GetPlayers()
        {
            throw new NotImplementedException();
        }

        public void ShufflePlayers()
        {
            throw new NotImplementedException();
        }

        public void SetAllPlayerLocationsTo(Int32 locationIndex)
        {
            throw new NotImplementedException();
        }

        public void SetLocationIndexFor(Int32 playerId, Int32 locationIndex)
        {
            throw new NotImplementedException();
        }

        public Int32 GetLocationIndexFor(Int32 playerId)
        {
            throw new NotImplementedException();
        }

        public void RemoveMoneyFrom(Int32 playerId, Int32 money)
        {
            throw new NotImplementedException();
        }

        public void AddMoneyTo(Int32 playerId, Int32 money)
        {
            throw new NotImplementedException();
        }

        public void ChargeTaxesTo(Int32 playerId, Func<Int32, Int32> taxEquation)
        {
            throw new NotImplementedException();
        }

        public void TransferMoney(Int32 givingPlayer, Int32 receivingPlayer, Int32 money)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public Int32 GetBalanceFor(Int32 playerId)
        {
            throw new NotImplementedException();
        }
    }
}
