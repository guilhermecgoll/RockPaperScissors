using RockPaperScissors.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RockPaperScissors
{
    public class Program
    {
        const int QTT_PLAYERS = 2;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.CallDefaultMatchWinner();
            p.CallDefaultTournament();

            Console.Read();
        }

        private void CallDefaultMatchWinner()
        {
            List<Player> players = new List<Player>();
            createPlayerAndAdd("Armando", Move.Paper, players);
            createPlayerAndAdd("Dave", Move.Scissors, players);

            Console.WriteLine($"The winner is {rps_game_winner(players)}");
        }

        private void CallDefaultTournament()
        {
            List<Player> players = new List<Player>();
            createPlayerAndAdd("Armando", Move.Paper, players);
            createPlayerAndAdd("Dave", Move.Scissors, players);
            createPlayerAndAdd("Richard", Move.Rock, players);
            createPlayerAndAdd("Michael", Move.Scissors, players);

            createPlayerAndAdd("Allen", Move.Scissors, players);
            createPlayerAndAdd("Omer", Move.Paper, players);
            createPlayerAndAdd("David. E", Move.Rock, players);
            createPlayerAndAdd("Richard X.", Move.Paper, players);

            Game[] games = createMatches(players);

            Console.WriteLine($"The tournament winner is {rps_tournament_winner(games)}");
        }

        public void createPlayerAndAdd(string nome, Move move, List<Player> addTo)
        {
			if (addTo == null)
			{
				throw new ArgumentNullException("The list to add to is null");
			}
			if (string.IsNullOrEmpty(nome))
			{
				throw new ArgumentNullException("The player name is null or empty");
			}

            Player p = new Player(nome, move);
            addTo.Add(p);
        }

        public Player rps_game_winner(List<Player> players)
        {
            //If the number of players is not equal to 2, raise WrongNumberOfPlayersError.
            if (players.Count != QTT_PLAYERS)
            {
                throw new WrongNumberOfPlayersError();
            }

            //If either player's strategy is something other than "R", "P" or "S" (case-insensitive), raise NoSuchStrategyError
            if (players.Any(p => !Regex.Match(p.move, @"[RrSsPp]").Success))
            {
                throw new NoSuchStrategyError();
            }

            Player winner = null;
            Player first = players[0];
            Player second = players[1];

            #region choosing the winner
            switch (first.move.ToUpper())
            {
                case "R":
                    if (Regex.Match(second.move, @"[RrSs]").Success)
                    {
                        winner = first;
                    }
                    else
                    {
                        winner = second;
                    }
                    break;
                case "S":
                    if (Regex.Match(second.move, @"[SsPp]").Success)
                    {
                        winner = first;
                    }
                    else
                    {
                        winner = second;
                    }
                    break;
                case "P":
                    if (Regex.Match(second.move, @"[PpRr]").Success)
                    {
                        winner = first;
                    }
                    else
                    {
                        winner = second;
                    }
                    break;
                default:
                    throw new NoSuchStrategyError();
            }
            #endregion

            return winner;
        }

        public Player rps_tournament_winner(Game[] games)
        {
            List<Player> winner = new List<Player>();

            Game[] matches = games;
            while (winner.Count != 1)
            {
                foreach (Game g in matches)
                {
                    winner.Add(rps_game_winner(g.players));
                }
                if (winner.Count > 1)
                {
                    matches = createMatches(winner);
                    winner.Clear();
                }
            }

            return winner.FirstOrDefault();
        }

        public Game[] createMatches(List<Player> players)
        {
            List<Game> games = new List<Game>();
            int half = players.Count / 2;

            int i = 0;
            while (players.Count >= (i + 1))
            {
                Game game = new Game();
                game.players.Add(players[i]);
                if (players.Count >= (i + 1))
                {
                    i++;
                    game.players.Add(players[i]);
                    i++;
                }
                else
                {
                    //add himself/ herself, so he/ she will automatically be the winner
                    game.players.Add(players[i]);
                    i++;
                }
                games.Add(game);
            }

            return games.ToArray();
        }
    }
}
