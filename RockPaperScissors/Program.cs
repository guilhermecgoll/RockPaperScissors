using RockPaperScissors.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        const int QTT_PLAYERS = 2;

        static void Main(string[] args)
        {
            Program p = new Program();
            Player rock = new Player("The Rock", Move.Rock);
            Player scissors = new Player("Edward Scissors Hands", Move.Scissors);
            Player paper = new Player("Toilet Paper", Move.Paper);

            List<Player> players = new List<Player>();
            players.Add(paper);
            players.Add(rock);

            Console.WriteLine($"O vencedor é {p.rps_game_winner(players)}");
            Console.Read();
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

        public Player rps_tournament_winner()
        {
            return null;
        }

    }
}
