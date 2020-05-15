using RockPaperScissors.Moves;
using System;

namespace RockPaperScissors
{
    public class Program
    {
        const int QTT_PLAYERS = 2;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.CallDefaultMatchWinner();
            p.CallDefaultTournament();

            Console.Read();
        }

        private void CallDefaultMatchWinner()
        {
            Player Armando = new Player("Armando", new MovePaper());
            Player Dave = new Player("Dave", new MoveScissors());

            Console.WriteLine($"The winner is {new Match(Armando, Dave).Winner()}");
        }

        private void CallDefaultTournament()
        {
            IMove movePaper = new MovePaper();
            IMove moveRock = new MoveRock();
            IMove moveScissors = new MoveScissors();

            Tournament tournament = new Tournament();
            tournament.SignUp(new Player("Armando", movePaper));
            tournament.SignUp(new Player("Dave", moveScissors));
            tournament.SignUp(new Player("Richard", moveRock));
            tournament.SignUp(new Player("Michael", moveScissors));

            tournament.SignUp(new Player("Allen", moveScissors));
            tournament.SignUp(new Player("Omer", movePaper));
            tournament.SignUp(new Player("David. E", moveRock));
            tournament.SignUp(new Player("Richard X.", movePaper));

            Console.WriteLine($"The tournament winner is {tournament.Winner()}");
        }

    }
}
