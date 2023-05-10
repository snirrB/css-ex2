using System;
using System.Dynamic;

internal class GameConfiguration
{
    private int m_SquareBoradSize = 0;
    private bool m_isTwoPlayets = false;
    private bool m_userPressExit = false;
    private string m_player1Name;
    private string m_player2Name;

    public int getSquareBoradSize()
    { 
        return m_SquareBoradSize;
    }

    public void setSquareBoradSize()
    {
        int numToCheck = 0;
        bool isInputVaild = false;
        string inputFromUser;
        
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

            
            string message = String.Format("the board size is {0}*{0}", numToCheck);
            Console.WriteLine(message);
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            
            Ex02.ConsoleUtils.Screen.Clear();
            
            isInputVaild = true;
            m_SquareBoradSize = numToCheck;

        }
    }

    public bool getIsTwoPlayets()
    {
        return m_isTwoPlayets;
    }

    public void setIsTwoPlayets()
    {
        int numToCheck = 0;
        bool isInputVaild = false;
        string inputFromUser;
        
        Console.WriteLine("==============================================");
        Console.WriteLine("               tic-tac-toe                   ");
        Console.WriteLine("new game - set who would you like to play with");
        Console.WriteLine("            to exit press Q                  ");
        Console.WriteLine("==============================================");


        while (!isInputVaild)
        {
            Console.WriteLine("");
            Console.WriteLine("Please choose whether to play against the computer or against another player");
            Console.WriteLine("select: 0 - computer , 1 - another player");

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

            if (numToCheck == 0)
            {
                m_isTwoPlayets = false;
                isInputVaild = true;
                continue;
            }

            if (numToCheck == 1)
            {
                m_isTwoPlayets = true;
                isInputVaild = true;
                continue;
            }
        }

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
        catch (Exception ex)
        {
            Console.WriteLine("Invalid input - not a natural number");
            inputFromUserAsInt = -1;
        }

        return inputFromUserAsInt;
    }


}

