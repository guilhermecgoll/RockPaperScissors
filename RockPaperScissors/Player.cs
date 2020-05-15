using RockPaperScissors.Exceptions;
using RockPaperScissors.Moves;

namespace RockPaperScissors
{
    public class Player
    {
        public string Name;
        private IMove Move;

        public Player(string name, IMove move)
        {
            this.Name = name;
            SetMove(move);
        }

        public void SetMove(IMove move)
        {
            this.Move = move ?? throw new InvallidMoveException();
        }

        public IMove GetMove()
        {
            return this.Move;
        }


        public override string ToString()
        {
            return $"player {Name} with move {Move.MoveKind()}";
        }

        public override bool Equals(object obj)
        {
            bool ret = false;
            if (obj != null)
            {
                Player p = (Player)obj;
                if (this.Name == p.Name &&
                    this.Move.MoveKind() == p.Move.MoveKind())
                {
                    ret = true;
                }
            }

            return ret;
        }
    }
}
