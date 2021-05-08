using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    public class InputManager
    {
        public static string getDataFromUser()
        {
            string userData;
            userData = Console.ReadLine();
            return userData;
        }

        public static int getValidNumFromUser(int i_MinValue, int i_MaxValue)
        {
            bool isValid = false;
            int validNum = 0;
            while (!isValid)
            {
                string userInput = getDataFromUser();
                if (userInput == "q" || userInput == "Q")
                {
                    GameManager.m_Qselected = true;
                    isValid = true;
                }
                else
                {
                    isValid = int.TryParse(userInput, out validNum);
                    if((validNum >= i_MinValue) && (validNum <= i_MaxValue))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        OutputManager.PrintInvalidNumberError();
                    }
                }
            }
            
            return validNum;
        }

        public static void GetSquareFromPlayer(int i_BoardSize, ref Board.Square i_SelectedSquare)
        {
            OutputManager.PrintRequestForRow();
            int userRowChoice = getValidNumFromUser(1, i_BoardSize);
            if(!GameManager.m_Qselected)
            {
                OutputManager.PrintRequestForCol();
                int userColChoice = getValidNumFromUser(1, i_BoardSize);
                if(!GameManager.m_Qselected)
                {
                    i_SelectedSquare.m_Row = userRowChoice;
                    i_SelectedSquare.m_Col = userColChoice;
                }
            }
        }
    }
}
