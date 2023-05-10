using System;
using System.Dynamic;

internal class GameConfiguration
{
    private int m_SquareBoradSize = 0;
    private bool m_isTwoPlayets;

    public void getSquareBoradSize()
    { 

        int m_SquareBoradSize = 0; // Initialize num to an invalid value

        while (m_SquareBoradSize < 3 || m_SquareBoradSize > 9)
        {
            Console.Write("Enter a number between 3 and 9: ");
            m_SquareBoradSize = int.Parse(Console.ReadLine());

            if (m_SquareBoradSize < 3 || m_SquareBoradSize > 9)
            {
                Console.WriteLine("Invalid number. Please try again.");
            }

            
        }





        Console.WriteLine("please enter the board game size");
        Console.WriteLine("please enter one natural number from 3-9");
        Console.WriteLine("the borad size will X*X (X is the entered number)");
        
        int num = int.Parse(Console.ReadLine());

        if (num >= 3 && num <= 9)
        {
            Console.WriteLine("The number is between 3 and 9.");
        }
        else
        {
            Console.WriteLine("The number is not between 3 and 9.");
        }
    }


}

