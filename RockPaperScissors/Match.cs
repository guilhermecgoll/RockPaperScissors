using RockPaperScissors.Exceptions;

namespace RockPaperScissors
{
    public class Match
    {
        private readonly Player PlayerOne;
        private readonly Player PlayerTwo;

        public Match(Player playerOne, Player playerTwo)
        {
            ValidateParameters(playerOne, playerTwo);

            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        private void ValidateParameters(Player playerOne, Player playerTwo)
        {
            if (playerOne == null || playerTwo == null)
            {
                throw new WrongNumberOfPlayersException();
            }
        }

        public Player Winner()
        {
            var _winner = PlayerOne;

            bool playersHaveDifMoves = PlayerOne.GetMove().MoveKind() != PlayerTwo.GetMove().MoveKind();

            if (playersHaveDifMoves &&
                PlayerTwo.GetMove().Win(PlayerOne.GetMove()))
            {
                _winner = PlayerTwo;
            }

            return _winner;
        }

        public override string ToString()
        {
            return $"A partida é entre {PlayerOne.Name} e {PlayerTwo.Name}";
        }
    }
}
