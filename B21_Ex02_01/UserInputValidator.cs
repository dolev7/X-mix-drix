using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    public class UserInputValidator
    {
        public static int getValidNumFromUser(int i_MinValue, int i_MaxValue)
        {
            bool isValid = false;
            int validNum = 0;
            string userInput;

            while (!isValid)
            {
                userInput = UIMachine.getDataFromUser();
                isValid = int.TryParse(userInput, out validNum);
                if ((validNum >= i_MinValue) && (validNum <= i_MaxValue))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    UIMachine.printMessageToUser("Please enter a correct number");
                }
            }

            return validNum;
        }
    }
}
