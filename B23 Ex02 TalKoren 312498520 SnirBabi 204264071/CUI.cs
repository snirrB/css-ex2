using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace B23_Ex02_TalKoren_312498520_SnirBabi_204264071
{
    internal class CUI
    {
        GameManager m_gameManager = new GameManager();
        GameConfiguration m_gameConfiguration = new GameConfiguration();
        bool m_isUserPressExit = false;

        public void getTheGameSettingFromUser()
        {
            m_gameConfiguration.SetBoradSize();

            if (m_gameConfiguration.getUserPressExit())
            {
                m_isUserPressExit = true;
                return;
            }
            
            m_gameConfiguration.setIsTwoPlayets();

            if (m_gameConfiguration.getUserPressExit())
            {
                m_isUserPressExit = true;
            }
        }

        public void startPlay()
        {
            m_gameManager.StartNewGame(m_gameConfiguration.GetIsTwoPlayersOrAgainstComputer(),m_gameConfiguration.GetBoradSize());
            m_gameManager.ResetGame();
            
            while (!m_isUserPressExit) 
            {
                Ex02.ConsoleUtils.Screen.Clear();
                
                printBoard();
                (int,int) move = GetMove();
                
                if (m_isUserPressExit)
                    continue;
                m_gameManager.PlayMove(move.Item1, move.Item2); // status
            }

            
        }

        private void printBoard()
        {
            char[,] matrix = m_gameManager.GetBoard().getMatrix();
            
            Console.Write("   ");
            
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(string.Format("| {0} ", j + 1));
            }
            Console.WriteLine("|");

            printSeparatorRow();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(string.Format(" {0} ", i + 1));

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(string.Format("| {0} ", matrix[i, j]));
                }
                Console.WriteLine("|");
                printSeparatorRow();
            }


        }

        private void printSeparatorRow() 
        {
            for (int j = 0; j < m_gameManager.GetBoard().getMatrix().GetLength(1); j++)
            {
                Console.Write("====");
            }
            Console.WriteLine("====");

        }

        private (int, int) GetMove()
        {
            int row = -1;
            int column = -1;
            bool validInput = false;
            string moveAsString;

            while (!validInput)
            {
                Console.WriteLine("");
                Console.WriteLine(m_gameManager.GetactivePlayer().Name + " - enter you move: ");
                moveAsString = Console.ReadLine();
                
                if (moveAsString == "Q")
                {
                    m_isUserPressExit = true;
                    validInput = true;
                    continue;
                }
                
                if (moveAsString.Length != 3 || moveAsString[1] != '-')
                {
                    Console.WriteLine("valid imput - please enter as row-column, For example: 3-4");
                    continue;
                }

                try
                {
                    row = int.Parse(moveAsString[0].ToString());
                    column = int.Parse(moveAsString[2].ToString());
                }
                catch
                {
                    Console.WriteLine("Invalid input - not a natural number");
                    row = -1;
                    column = -1;
                    continue;
                }

                if (row < 1 || row >= m_gameConfiguration.GetBoradSize())
                {
                    Console.WriteLine("Invalid input - row number is incorrect");
                    continue;
                }

                if (column < 1 || column >= m_gameConfiguration.GetBoradSize())
                {
                    Console.WriteLine("Invalid input - column number is incorrect");
                    continue;
                }

                validInput = true;
            }

            return (row, column);
        }

        public bool getUserPressExit() 
        {
            return m_isUserPressExit;
        }

        public void newGameMenu(ref bool o_endGame)
        {
            int userInput = -1;
            bool invalidInput = false;
            Ex02.ConsoleUtils.Screen.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("               tic-tac-toe                   ");
            Console.WriteLine("==============================================");

            while (!invalidInput)
            {
                Console.WriteLine("");
                Console.WriteLine("Do you want to start a new game? please enter a numer from the menu:");
                Console.WriteLine("1. yes");
                Console.WriteLine("2. no");

                try
                {
                    userInput = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input - not a natural number");
                    userInput = -1;
                    continue;
                }

                if (userInput == 1)
                {
                    o_endGame = false;
                    invalidInput = true;
                    continue;
                }

                if (userInput == 2 )
                {
                    o_endGame = true;
                    invalidInput = true;
                    Console.WriteLine("Bye Bye");
                    continue;
                }

                Console.WriteLine("Invalid input - Please select a number from the menu");

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            CUI cUI = null;
            bool endGame = false;


            while (!endGame)
            {
                cUI = new CUI();
                cUI.getTheGameSettingFromUser();
                
                if (cUI.getUserPressExit())
                {
                    cUI.newGameMenu(ref endGame);
                    continue;
                }

                cUI.startPlay();

                cUI.newGameMenu(ref endGame);
            }
        }
    }

}