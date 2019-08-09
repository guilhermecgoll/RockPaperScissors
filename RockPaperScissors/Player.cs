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

        public Player(string name, Move move)
        {
            this.name = name;
            this.move = GetNameByMove(move);
        }

        private string GetNameByMove(Move move)
        {
            string ret = string.Empty;
            switch (move)
            {
                case Move.Paper:
                    ret = "P";
                    break;
                case Move.Rock:
                    ret = "R";
                    break;
                case Move.Scissors:
                    ret = "S";
                    break;
            }
            return ret;
        }

        public override string ToString()
        {
            return $"jogador {name} com o movimento {move}";
        }
    }
}
