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
            OutputManager.PrintRequestForBoardSize();
            int boardSize = InputManager.getValidNumFromUser(k_MinBoardSize, k_MaxBoardSize);
            OutputManager.printRequestForGameMode();
            int usersChoiceOfGameMode = InputManager.getValidNumFromUser(k_GameModeOptionOne, k_GameModeOptionTwo);

            GameManager xogame = new GameManager();
            xogame.InitGame(boardSize, usersChoiceOfGameMode);
            xogame.PlayGame();
        }

    }
}
