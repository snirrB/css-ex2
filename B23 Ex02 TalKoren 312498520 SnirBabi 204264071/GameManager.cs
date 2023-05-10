using System;
namespace B23_Ex02_TalKoren_312498520_SnirBabi_204264071
{
	public class GameManager
	{
		private GameMode m_mode;
		private GameStatus m_status;
		private Board m_board;
		private Player m_activePlayer;
		private Pair<Player, Player> m_players;

		public GameManager()
		{
			m_status = GameStatus.Pending;
		}

		public void StartNewGame(GameMode i_mode, int i_boardSize)
		{
			if(m_status != GameStatus.Pending)
			{
				//Todo - throw exception
			}
			m_mode = i_mode;
			m_board = new Board(i_boardSize);
			m_players = new Pair<Player, Player>();
			setPlayersByMode();
			m_activePlayer = m_players.First;
        }

		public void ResetGame()
		{
            if (m_status != GameStatus.Pending)
            {
                //Todo - throw exception
            }
            m_board.Reset();
			m_activePlayer = m_players.First;
		}

		public bool PlayMove(int i_row, int i_column)
		{
			if (m_status != GameStatus.Running && m_board.IsFull())
			{
				//Todo- throw exception
			}
			bool isPlayed = m_board.MarkCell(m_activePlayer.Mark, i_row, i_column);
			if (isPlayed && !m_board.isLost())
			{
				m_activePlayer = m_activePlayer.Mark == m_players.First.Mark ? m_players.Second : m_players.First;
                if (!m_board.IsFull() && m_mode == GameMode.AgainstComputer)
                {
                    computerMove();
                }
            }


			return isPlayed;
		}

        private char[,] cloneMatrix(char[,] i_matrix)
        {
            char[,] copy = new char[i_matrix.Length, i_matrix.Length];
            for (int i = 0; i < i_matrix.Length; ++i)
            {
                for (int j = 0; j < i_matrix.Length; ++j)
                {
                    copy[i, j] = i_matrix[i, j];
                }
            }

            return copy;
        }

        private void setPlayersByMode()
		{
            m_players.First = new Player("Player1", 'X', Player.Type.regular);
            if (m_mode == GameMode.TwoPlayers)
			{
                m_players.Second = new Player("Player1", 'O', Player.Type.regular);
            }
			else
			{
                m_players.Second = new Player("Player1", 'O', Player.Type.computer);
            }
		}
		
		private void computerMove()
		{

			Random rand = new Random();
			bool isPlayed = false;
			int row, col;
			int cellBorder = m_board.Matrix.Length;

			while (!isPlayed)
			{
				row = rand.Next(cellBorder);
				col = rand.Next(cellBorder);
				isPlayed = m_board.MarkCell(m_activePlayer.Mark, row, col);
			}

			m_activePlayer = m_players.First;

		}

		public enum GameStatus
		{
			Running,
			Pending
		}

		public enum GameMode
		{
			TwoPlayers,
			AgainstComputer
		}

		public struct Player
		{
			private string m_name;
			private char m_mark;
			private Type m_type;

			public Player(string i_name, char i_mark, Type i_type)
			{
				m_name = i_name;
				m_mark = i_mark;
				m_type = i_type;
			}

			public string Name
			{
				get { return m_name; }
				set { m_name = value; }
			}

			public char Mark
			{
				get { return m_mark; }
				set { m_mark = value; }
			}

			public Type PlayerType
			{
				get { return m_type; }
				set { m_type = value; }
			}

			public enum Type
			{
				computer,
				regular
			}
		}

		public struct GameResults
		{
			public string Loser { get; set; }
            public string Winner { get; set; }
			public char[,] Board { get; set; }
			public Result GameResult { get; set; }

			public GameResults(string i_loser, string i_winner, char[,] i_board, Result i_result)
			{
				Loser = i_loser;
				Winner = i_winner;
				Board = i_board;
				GameResult = i_result;
			}

            public enum Result
			{
				Defeat,
				Draw,
				Play
			}
		}
	}
}

