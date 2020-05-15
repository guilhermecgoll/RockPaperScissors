using RockPaperScissors.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors
{
    public class Tournament
    {
        private readonly List<Player> Players;
        private bool openForSubscriptions = true;
        private readonly List<Player> FinalWinner;

        public Tournament()
        {
            Players = new List<Player>();
            FinalWinner = new List<Player>();
        }

        public void SignUp(Player newPlayer)
        {
            if (!openForSubscriptions)
            {
                throw new TournamentClosedException();
            }
            if (Players.Contains(newPlayer))
            {
                throw new PlayerAlreadySubscribedException(newPlayer.Name);
            }

            Players.Add(newPlayer);
        }

        public Player Winner()
        {
            InitializeRun();
            while (FinalWinner.Count > 1)
            {
                ChooseWinner();
            }

            return FinalWinner.First();
        }

        private void InitializeRun()
        {
            openForSubscriptions = false;
            if (!Players.Any())
            {
                throw new ZeroPlayersSubscribedException();
            }

            FinalWinner.AddRange(Players);
        }

        private void ChooseWinner()
        {
            List<Match> matchesInRound = new List<Match>();
            CreateMatches(matchesInRound);
            RunMatches(matchesInRound);
        }

        private void CreateMatches(List<Match> matchesInRound)
        {
            int amountMatches = FinalWinner.Count;
            for (int i = 0; i < amountMatches; i++)
            {
                var playerOne = FinalWinner[i];
                var playerTwo = playerOne;
                if (FinalWinner[i + 1] != null)
                {
                    i++;
                    playerTwo = FinalWinner[i];
                }
                matchesInRound.Add(new Match(playerOne, playerTwo));
            }
        }

        private void RunMatches(List<Match> matchesInRound)
        {
            FinalWinner.Clear();
            matchesInRound.ForEach(m => FinalWinner.Add(m.Winner()));
        }
    }
}
