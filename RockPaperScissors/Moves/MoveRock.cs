namespace RockPaperScissors.Moves
{
    public class MoveRock : IMove
    {
        public EMove Beats()
        {
            return EMove.Scissors;
        }

        public bool Loose(IMove move)
        {
            return move.Win(this);
        }

        public EMove Looses()
        {
            return EMove.Paper;
        }

        public EMove MoveKind()
        {
            return EMove.Rock;
        }

        public bool Win(IMove move)
        {
            return Beats() == move.MoveKind();
        }
    }
}
