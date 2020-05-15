namespace RockPaperScissors.Moves
{
    public interface IMove
    {
        EMove MoveKind();
        EMove Beats();
        EMove Looses();

        bool Win(IMove move);
        bool Loose(IMove move);

    }
}
