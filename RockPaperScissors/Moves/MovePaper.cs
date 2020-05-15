namespace RockPaperScissors.Moves
{
    public class MovePaper : IMove
    {
        public EMove Beats()
        {
            return EMove.Rock;
        }

        public bool Loose(IMove move)
        {
            return move.Win(this);
        }

        public EMove Looses()
        {
            return EMove.Scissors;
        }

        public EMove MoveKind()
        {
            return EMove.Paper;
        }

        public bool Win(IMove move)
        {
            return Beats() == move.MoveKind();
        }
    }
}
