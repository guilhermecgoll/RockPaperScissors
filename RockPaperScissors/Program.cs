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

            switch (first.move.ToUpper())
            {
                case "R":
                    if (Regex.Match(players[1].move, @"[]").Success)
                    {

                    } else
                    {
                        winner = players
                    }
                    break;
                case "S":
                    break;
                case "P":
                    break;
                default:
                    throw new NoSuchStrategyError();
            }

            return players.FirstOrDefault();
        }

    }
}
