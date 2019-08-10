using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    class Game
    {
        public List<Player> players = new List<Player>();

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder("A partida é entre ");
            players.ForEach(p => ret.Append(p.ToString().Trim('.')));

            return ret.ToString();
        }
    }
}
