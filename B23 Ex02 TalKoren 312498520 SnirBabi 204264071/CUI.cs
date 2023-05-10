using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;


internal class CUI
{
    //GameLogic gameLogic;
    //Ex02.ConsoleUtils.Screen.Clear();
    GameConfiguration gameConfiguration = new GameConfiguration();
    public void getTheGameSettingFromUser()
    {
        gameConfiguration.setSquareBoradSize();

        if (!gameConfiguration.getUserPressExit())
        {
            gameConfiguration.setIsTwoPlayets();
        }
            
    }

    public void startPlay()
    {
        
        
    }






}

class Program
{
    static void Main(string[] args)
    {
        CUI cUI = new CUI();

        cUI.getTheGameSettingFromUser();

    }
}