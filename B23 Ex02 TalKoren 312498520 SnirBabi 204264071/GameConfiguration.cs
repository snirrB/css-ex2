using System;
using System.Dynamic;
using static B23_Ex02_TalKoren_312498520_SnirBabi_204264071.GameManager;

internal class GameConfiguration
{
    private int m_BoradSize = 0;
    private GameMode? m_gameMode = null;
    private bool m_userPressExit = false;
    //private string m_player1Name;
    //private string m_player2Name;

    public int GetBoradSize()
    { 
        return m_BoradSize;
    }

    public void SetBoradSize()
    {
        int numToCheck = 0;
        bool isInputVaild = false;
        string inputFromUser;

        Ex02.ConsoleUtils.Screen.Clear();

        Console.WriteLine("==============================================");
        Console.WriteLine("               tic-tac-toe                   ");
        Console.WriteLine("     new game - set the size of the borad    ");
        Console.WriteLine("            to exit press Q                  ");
        Console.WriteLine("==============================================");


        while (!isInputVaild)
        {
            Console.WriteLine("");
            Console.WriteLine("please enter the board game size");
            Console.WriteLine("please enter one natural number from 3-9");
            Console.WriteLine("the borad size will X*X (X is the entered number)");

            inputFromUser = Console.ReadLine();

            if (IsUserChoseToExit(inputFromUser) == true)
            {
                isInputVaild = true;
                continue;
            }

            numToCheck = ParseIntFromString(inputFromUser);

            if (numToCheck == -1)
            {
                continue;
            }

            if (numToCheck < 3 || numToCheck > 9)
            {
                Console.WriteLine("Invalid input. please enter one natural number from 3-9.");
                continue;
            }

            Ex02.ConsoleUtils.Screen.Clear();

            string message = String.Format("the board size is {0}*{0}", numToCheck);
            Console.WriteLine(message);
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            isInputVaild = true;
            m_BoradSize = numToCheck;
        }
    }

    public GameMode GetIsTwoPlayersOrAgainstComputer()
    {
        return m_gameMode.Value;
    }

    public void setIsTwoPlayets()
    {
        int numToCheck = 0;
        bool isInputVaild = false;
        string inputFromUser;

        Ex02.ConsoleUtils.Screen.Clear();

        Console.WriteLine("==============================================");
        Console.WriteLine("               tic-tac-toe                   ");
        Console.WriteLine("new game - set who would you like to play with");
        Console.WriteLine("            to exit press Q                  ");
        Console.WriteLine("==============================================");


        while (!isInputVaild)
        {
            Console.WriteLine("");
            Console.WriteLine("Please choose whether to play against the computer or against another player");
            Console.WriteLine("1.computer");
            Console.WriteLine("2.another player");

            inputFromUser = Console.ReadLine();

            if (IsUserChoseToExit(inputFromUser) == true)
            {
                isInputVaild = true;
                continue;
            }

            numToCheck = ParseIntFromString(inputFromUser);

            if (numToCheck == -1)
            {
                continue;
            }

            if (numToCheck == 1)
            {
                m_gameMode = GameMode.AgainstComputer;
                isInputVaild = true;
                //setPlayerName(ref m_player1Name,1);
                
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("You chose a game against the computer");
                //Console.WriteLine("your name is: " + m_player1Name);
                
                continue;
            }

            if (numToCheck == 2)
            {
                m_gameMode = GameMode.TwoPlayers;
                //setPlayerName(ref m_player1Name, 1);
                //setPlayerName(ref m_player2Name, 2);
                isInputVaild = true;

                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("You chose a game against the another player");
                //Console.WriteLine("player 1 name is: " + m_player1Name);
                //Console.WriteLine("player 2 name is: " + m_player2Name);
                
                continue;
            }

            Console.WriteLine("invalid input - please choose 1 or 2");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

    }

    public bool getUserPressExit() 
    {
        return m_userPressExit;
    }

    private bool IsUserChoseToExit(String userInput) 
    {

        if (userInput == "Q")
        {
            m_userPressExit = true;
        }

        return m_userPressExit;
    }

    private int ParseIntFromString(String userInput) {

        int inputFromUserAsInt = 0;

        try
        {
            inputFromUserAsInt = int.Parse(userInput);
        }
        catch
        {
            Console.WriteLine("Invalid input - not a natural number");
            inputFromUserAsInt = -1;
        }

        return inputFromUserAsInt;
    }

    private void setPlayerName(ref string palyer,int playerNumber)
    {
        Console.WriteLine("");
        Console.WriteLine("Please enter the name of palyer " + playerNumber + ": ");
        palyer = Console.ReadLine();
    }
}

