using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors;
using RockPaperScissors.Moves;

namespace RockPaperScissorsTest
{
    [TestClass]
    public class ProgramTest
    {
        private IMove ScissorsMove;
        private IMove PaperMove;
        private IMove RockMove;

        [TestInitialize]
        public void TestInitialize()
        {
            ScissorsMove = new MoveScissors();
            PaperMove = new MovePaper();
            RockMove = new MoveRock();
        }


        [TestMethod]
        public void TesteGanhadorComMovimentosDiferentes()
        {
            Player p1 = new Player("Armando", PaperMove);
            Player p2 = new Player("Dave", ScissorsMove);

            Assert.AreEqual(p2, new Match(p1, p2).Winner(), "Erro ao verificar ganhador com movimentos diferentes: Scissors > Paper");

            p2.SetMove(RockMove);
            Assert.AreEqual(p1, new Match(p1, p2).Winner(), "Erro ao verificar ganhador com movimentos diferentes: Paper > Rock ");

            p1.SetMove(RockMove);
            p2.SetMove(ScissorsMove);

            Assert.AreEqual(p1, new Match(p1, p2).Winner(), "Erro ao verificar ganhador com movimentos diferentes: Rock > Scissors");
        }

        [TestMethod]
        public void TesteGanhadorComMovimentosIguais()
        {
            Player p1 = new Player("Armando", PaperMove);
            Player p2 = new Player("Dave", PaperMove);

            Assert.AreEqual(p1, new Match(p1, p2).Winner(), "Erro ao verificar ganhador com movimentos iguais");
            Assert.AreEqual(p2, new Match(p2, p1).Winner(), "Erro ao verificar ganhador com movimentos iguais");
        }

        [TestMethod]
        public void TesteGanhadorTorneio()
        {
            Tournament tournament = new Tournament();

            tournament.SignUp(new Player("Armando", PaperMove));
            tournament.SignUp(new Player("Dave", ScissorsMove));
            Player Richard = new Player("Richard", RockMove);
            tournament.SignUp(Richard);
            tournament.SignUp(new Player("Michael", ScissorsMove));

            tournament.SignUp(new Player("Allen", ScissorsMove));
            tournament.SignUp(new Player("Omer", PaperMove));
            tournament.SignUp(new Player("David. E", RockMove));
            tournament.SignUp(new Player("Richard X.", PaperMove));

            Assert.AreEqual(Richard, tournament.Winner(), "Erro ao verificar ganhador do torneio");
        }

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TesteCriarEIncluirJogadorNaListaNula()
        //{
        //    Program p = new Program();

        //    p.createPlayerAndAdd("nome", EMove.Paper, null);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TesteCriarEIncluirJogadorNaListaComJogadorSemNome()
        //{
        //    Program p = new Program();

        //    p.createPlayerAndAdd(string.Empty, EMove.Paper, new List<Player>());
        //}

        //[TestMethod]
        //public void TesteCriarEIncluirJogadorNaLista()
        //{
        //    Program p = new Program();
        //    List<Player> lista = new List<Player>();

        //    p.createPlayerAndAdd("João", EMove.Paper, lista);

        //    Assert.AreEqual(1, lista.Count);
        //    Assert.AreEqual(new Player("João", EMove.Paper), lista[0]);
        //}
    }
}
