using System;

namespace B21_Ex02_01
{
    public class InputManager
    {
        public static string GetDataFromUser()
        {
            string userData = Console.ReadLine();
            return userData;
        }

        public static int GetValidNumFromUser(int i_MinValue, int i_MaxValue)
        {
            bool isValid = false;
            int validNum = 0;
            while (!isValid)
            {
                string userInput = GetDataFromUser();
                if (userInput == GameManager.k_QuitSymbolOne || userInput == GameManager.k_QuitSymbolOne)
                {
                    GameManager.m_QSelected = true;
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
            int userRowChoice = GetValidNumFromUser(1, i_BoardSize);
            if(!GameManager.m_QSelected)
            {
                OutputManager.PrintRequestForCol();
                int userColChoice = GetValidNumFromUser(1, i_BoardSize);
                if(!GameManager.m_QSelected)
                {
                    i_SelectedSquare.m_Row = userRowChoice;
                    i_SelectedSquare.m_Col = userColChoice;
                }
            }
        }
    }
}
