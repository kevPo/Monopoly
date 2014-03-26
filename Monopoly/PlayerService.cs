using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class PlayerService
    {
        //private IPlayerRepository playerRepository;

        //public PlayerService(IPlayerRepository playerRepository)
        //{
        //    this.playerRepository = playerRepository;
        //}

        //public void RemoveMoneyFrom(Int32 playerId, Int32 money)
        //{
        //    var player = playerRepository.GetPlayer(playerId);
        //    player.RemoveMoney(money);
        //    playerRepository.UpdatePlayer(player);
        //}

        //public void AddMoneyTo(Int32 playerId, Int32 money)
        //{
        //    var player = GetPlayer(playerId);
        //    player.RemoveMoney(money);
        //}

        //public void ChargeTaxesTo(Int32 playerId, Func<Int32, Int32> taxEquation)
        //{
        //    var player = GetPlayer(playerId);
        //    var taxes = taxEquation(player.Balance);
        //    player.RemoveMoney(taxes);
        //}

        //public void TransferMoney(Int32 givingPlayerId, Int32 receivingPlayerId, Int32 money)
        //{
        //    var givingPlayer = GetPlayer(givingPlayerId);
        //    var receivingPlayer = GetPlayer(receivingPlayerId);
        //    givingPlayer.RemoveMoney(money);
        //    receivingPlayer.ReceiveMoney(money);
        //}
    }
}
