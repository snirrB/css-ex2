using System;
using System.Collections.Generic;

namespace B23_Ex02_TalKoren_312498520_SnirBabi_204264071
{
	public class Board
	{
		private char[,] m_matrix;
		private int m_availableMoves;
		private Cell m_lastMarked;

		public char[,] Matrix
		{
			get { return cloneMatrix(); }
		}

   
        public Board(int i_matixSize)
		{
			m_matrix = new char[i_matixSize, i_matixSize];
			m_availableMoves = (int) Math.Pow(i_matixSize, 2);
		}

		public bool MarkCell(char i_sign, int i_row, int i_column)
		{
			if (m_matrix[i_row, i_column] != '\0')
			{
				m_matrix[i_row, i_column] = i_sign;
				m_availableMoves--;
				return true;
            }
			return false;
		}

		public void Reset()
		{
			for(int i = 0; i < m_matrix.Length; ++i)
			{
				for(int j = 0; j < m_matrix.Length; ++j)
				{
					m_matrix[i, j] = '\0';
				}
			}
		}

		public bool IsFull()
		{
			return m_availableMoves == 0;
        }

		
		private char[,] cloneMatrix()
		{
			char[,] copy = new char[m_matrix.Length, m_matrix.Length];
            for (int i = 0; i < m_matrix.Length; ++i)
            {
                for (int j = 0; j < m_matrix.Length; ++j)
                {
                    copy[i, j] = m_matrix[i,j];
                }
            }

			return copy;
        }



		private struct Cell
		{
			public int Row { get; set; }
			public int Col { get; set; }

			public Cell (int i_row, int i_col)
			{
				Row = i_row;
				Col = i_col;
			}
		}
    }
}

