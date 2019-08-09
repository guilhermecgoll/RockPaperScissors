using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class Player
    {
        public string name;
        public string move;

        public Player(string name, string move)
        {
            this.name = name;
            this.move = move;
        }
    }
}
