using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    public class UI
    {
        public const int k_MaxBoardSize = 9;
        public const int k_MinBoardSize = 3;
        public const int k_GameModeOptionOne = 1;
        public const int k_GameModeOptionTwo = 2;
        public const char k_SymbolOne = 'X';
        public const char k_SymbolTwo = 'O';
        public static void RunGame()
        {
            OutputManager.printMessageToUser("Please enter size of XO board");
            int boardSize = InputManager.getValidNumFromUser(k_MinBoardSize, k_MaxBoardSize);
            OutputManager.printMessageToUser
(@"Please choose the game mode:
For XO game against the computer - press 1
For XO game against a human player - press 2");
            int usersChoiceOfGameMode = InputManager.getValidNumFromUser(k_GameModeOptionOne, k_GameModeOptionTwo);

            GameManager xogame = new GameManager();
            xogame.InitGame(boardSize, usersChoiceOfGameMode);
            OutputManager.drawBoard(xogame.GameBoard);
            xogame.PlayGame();
        }
        public static int GetRowFromPlayer(int i_BoardSize)
        {
            OutputManager.printMessageToUser("Please enter row number");
            return InputManager.getValidNumFromUser(1, i_BoardSize);            
        }
        public static int GetColFromPlayer(int i_BoardSize)
        {
            OutputManager.printMessageToUser("Please enter col number");
            return InputManager.getValidNumFromUser(1, i_BoardSize);
        }

    }
}
