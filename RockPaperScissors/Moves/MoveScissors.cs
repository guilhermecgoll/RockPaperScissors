namespace RockPaperScissors.Moves
{
    public class MoveScissors : IMove
    {
        public EMove Beats()
        {
            return EMove.Paper;
        }

        public bool Loose(IMove move)
        {
            return move.Win(this);
        }

        public EMove Looses()
        {
            return EMove.Rock;
        }

        public EMove MoveKind()
        {
            return EMove.Scissors;
        }

        public bool Win(IMove move)
        {
            return Beats() == move.MoveKind();
        }
    }
}
