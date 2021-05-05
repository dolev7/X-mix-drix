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
        public static int getValidNumFromUser(int i_MinValue, int i_MaxValue)
        {
            bool isValid = false;
            int validNum = 0;
            while (!isValid)
            {
                string userInput = getDataFromUser();
                isValid = int.TryParse(userInput, out validNum);
                if ((validNum >= i_MinValue) && (validNum <= i_MaxValue))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    OutputManager.printMessageToUser("Please enter a correct number");
                }
                
            }

            return validNum;
        }
    }
}
