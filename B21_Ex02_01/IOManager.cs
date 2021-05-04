using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    class IOManager
    {
        public static void printMessageToUser(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        public static void printMessageToUser(StringBuilder i_Message)
        {
            Console.WriteLine(i_Message);
        }

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
                    printMessageToUser("Please enter a correct number");
                }
            }

            return validNum;
        }
    }
}
