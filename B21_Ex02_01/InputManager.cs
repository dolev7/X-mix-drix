using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    class InputManager
    {
        public static string getDataFromUser()
        {
            string userData;
            userData = Console.ReadLine();
            return userData;
        }
        public static int getValidNumFromUser(int i_MinValue, int i_MaxValue, ref bool io_IsQ)
        {
            bool isValid = false;
            int validNum = 0;
            while (!isValid)
            {
                string userInput = getDataFromUser();
                if (userInput == "q")
                {
                    io_IsQ = true;
                    isValid = true;
                }
                isValid = int.TryParse(userInput, out validNum);
                if ((validNum >= i_MinValue) && (validNum <= i_MaxValue))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    OutputManager.PrintInvalidNumberError();
                }
                
            }

            return validNum;
        }

        public static Board.Square GetSquareFromPlayer(int i_BoardSize)
        {
            OutputManager.PrintRequestForRow();
            int userRowChoice = getValidNumFromUser(1, i_BoardSize);
            OutputManager.PrintRequestForCol();
            int userColChoice = getValidNumFromUser(1, i_BoardSize);
            Board.Square userSquareChoice = new Board.Square() { m_Row = userRowChoice, m_Col = userColChoice };

            return userSquareChoice;
        }
    }
}
