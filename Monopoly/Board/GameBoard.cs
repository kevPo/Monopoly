using System;
using System.Collections.Generic;
using Monopoly.Players;
using Monopoly.Turns;

namespace Monopoly.Board
{
    public class GameBoard : IBoard
    {
        private IPlayerRepository playerRepository;
        protected IEnumerable<Int32> playerIds;
        private ITurnFactory turnFactory;
        
        public GameBoard(IPlayerRepository playerRepository, ITurnFactory turnFactory)
        {
            this.playerRepository = playerRepository;
            this.turnFactory = turnFactory;
            playerRepository.ShufflePlayers();
            playerIds = playerRepository.GetPlayerIds();
        }

        public void PlayRound()
        {
            foreach (var playerId in playerIds)
                TakeTurnFor(playerId);
        }

        protected virtual void TakeTurnFor(Int32 playerId)
        {
            var turn = turnFactory.GetTurnFor(playerId);
            turn.Take();
        }
    }
}
