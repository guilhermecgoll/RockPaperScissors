using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors;

namespace RockPaperScissorsTest
{
	[TestClass]
	public class ProgramTest
	{
		[TestMethod]
		public void TesteGanhadorComMovimentosDiferentes()
		{
			Program p = new Program();

			List<Player> players = new List<Player>();
			Player p1 = new Player("Armando", Move.Paper);
			Player p2 = new Player("Dave", Move.Scissors);
			players.Add(p1);
			players.Add(p2);

			Assert.AreEqual(p2, p.rps_game_winner(players), "Erro ao verificar ganhador com movimentos diferentes: Scissors > Paper");

			players = new List<Player>();
			p1 = new Player("Armando", Move.Paper);
			p2 = new Player("Dave", Move.Rock);
			players.Add(p1);
			players.Add(p2);
			Assert.AreEqual(p1, p.rps_game_winner(players), "Erro ao verificar ganhador com movimentos diferentes: Paper > Rock ");

			players = new List<Player>();
			p1 = new Player("Armando", Move.Rock);
			p2 = new Player("Dave", Move.Scissors);
			players.Add(p1);
			players.Add(p2);
			Assert.AreEqual(p1, p.rps_game_winner(players), "Erro ao verificar ganhador com movimentos diferentes: Rock > Scissors");
		}

		[TestMethod]
		public void TesteGanhadorComMovimentosIguais()
		{
			Program p = new Program();

			List<Player> players = new List<Player>();
			Player p1 = new Player("Armando", Move.Paper);
			Player p2 = new Player("Dave", Move.Paper);
			players.Add(p1);
			players.Add(p2);

			Assert.AreEqual(p1, p.rps_game_winner(players), "Erro ao verificar ganhador com movimentos iguais");
		}

		[TestMethod]
		public void TesteGanhadorTorneio()
		{
			Program p = new Program();

			List<Player> players = new List<Player>();
			Player Armando = new Player("Armando", Move.Paper);
			Player Dave = new Player("Dave", Move.Scissors);
			Player Richard = new Player("Richard", Move.Rock);
			Player Michael = new Player("Michael", Move.Scissors);

			Player Allen = new Player("Allen", Move.Scissors);
			Player Omer = new Player("Omer", Move.Paper);
			Player DavidE = new Player("David. E", Move.Rock);
			Player RichardX = new Player("Richard X.", Move.Paper);

			players.AddRange(new []{ Armando, Dave, Richard, Michael, Allen, Omer, DavidE, RichardX });

			Game[] games = p.createMatches(players);

			Assert.AreEqual(Richard, p.rps_tournament_winner(games), "Erro ao verificar ganhador do torneio");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TesteCriarEIncluirJogadorNaListaNula()
		{
			Program p = new Program();

			p.createPlayerAndAdd("nome", Move.Paper, null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TesteCriarEIncluirJogadorNaListaComJogadorSemNome()
		{
			Program p = new Program();

			p.createPlayerAndAdd(string.Empty, Move.Paper, new List<Player>());
		}

		[TestMethod]
		public void TesteCriarEIncluirJogadorNaLista()
		{
			Program p = new Program();
			List<Player> lista = new List<Player>();

			p.createPlayerAndAdd("João", Move.Paper, lista);

			Assert.AreEqual(1, lista.Count);
			Assert.AreEqual(new Player("João", Move.Paper), lista[0]);
		}
	}
}
