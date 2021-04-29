using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    public class XOGame
    {
        public static void StartGame()
        {
            bool gameContinues = true;
            bool gameAgainstComputer;
            Console.WriteLine("Please enter size of XO matrix");
            int boardSize = getValidNumFromUser(Constants.MIN_BOARD_SIZE, Constants.MAX_BOARD_SIZE); 
            Board board = new Board(boardSize);
            Console.WriteLine("Please choose the game mode");
            Console.WriteLine("For XO game against the computer - press 1, For XO game against a human player - press 2");
            string userInput;
            userInput = Console.ReadLine();
            int usersChoiceOfGameMode = getValidNumFromUser(Constants.GAME_MODE_OPTION1, Constants.GAME_MODE_OPTION2);
            if (usersChoiceOfGameMode==Constants.GAME_MODE_OPTION1)
            {
                gameAgainstComputer = true;
            }
            else
            {
                gameAgainstComputer = false;
            }

            BoardDrawer.drawBoard(board);

            while (gameContinues)
            {
                Console.WriteLine("Please enter number of rows");
                int selectedRow = getValidNumFromUser(1, boardSize);
                Console.WriteLine("Please enter number of cols");
                int selectedCol = getValidNumFromUser(1, boardSize);
                board.addShape('x', selectedRow-1, selectedCol-1);
                BoardDrawer.drawBoard(board);
            }
        }

        public static int getValidNumFromUser(int i_MinValue, int i_MaxValue)
        {
            bool isValid = false;
            int validNum=0;
            string userInput;

            while (!isValid)
            {
                userInput = Console.ReadLine();
                isValid = int.TryParse(userInput, out validNum);
                if ((validNum >= i_MinValue) && (validNum <= i_MaxValue))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    Console.WriteLine("Please enter a correct number");
                }
            }

            return validNum;

        }

    }

}
