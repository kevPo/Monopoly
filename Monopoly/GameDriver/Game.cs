using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Turns;

namespace Monopoly.GameDriver
{
    public class Game
    {
        public List<Int32> PlayerIds { get; private set; }
        public Int32 Rounds { get; private set; }
        private ITurnFactory turnFactory;
        private Dictionary<Int32, Int32> playerTurns;
        private List<Int32> turnsSummary;

        public Game(IEnumerable<Int32> playerIds, ITurnFactory turnFactory)
        {
            this.PlayerIds = playerIds.ToList();
            this.turnFactory = turnFactory;
            this.Rounds = 0;

            PlayerIds = PlayerIds.Shuffle();
            SetUpPlayerTurns();
        }

        private void SetUpPlayerTurns()
        {
            turnsSummary = new List<Int32>();
            playerTurns = new Dictionary<Int32, Int32>();

            foreach (var id in PlayerIds)
                playerTurns.Add(id, 0);
        }

        public void Play()
        {
            for (var i = 0; i < 20; i++)
                PlayRound();
        }

        private void PlayRound()
        {
            Rounds++;
            foreach (var playerId in PlayerIds)
                TakeTurnFor(playerId);
        }

        private void TakeTurnFor(Int32 playerId)
        {
            var turn = turnFactory.GetTurnFor(playerId);
            turn.Take();
            AddTurnFor(playerId);
        }

        private void AddTurnFor(Int32 playerId)
        {
            playerTurns[playerId]++;
            turnsSummary.Add(playerId);
        }

        public Int32 GetTotalTurnsFor(Int32 playerId)
        {
            return playerTurns[playerId];
        }

        public String GetTurnsSummary()
        {
            return String.Join(",", turnsSummary);
        }
    }
}
