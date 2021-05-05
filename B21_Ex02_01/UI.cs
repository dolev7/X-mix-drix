using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    public class UI
    {
        public static void  RunGame()
        {
            GameManager xoGame = new GameManager();
            OutputManager.PrintRequestForBoardSize();
            int boardSize = InputManager.getValidNumFromUser(GameManager.k_MinBoardSize, GameManager.k_MaxBoardSize);
            GameManager.CheckForUserWithdraw();
            OutputManager.printRequestForGameMode();
            int usersChoiceOfGameMode = InputManager.getValidNumFromUser((int)GameManager.eGameModes.GameModeOptionOne, (int)GameManager.eGameModes.GameModeOptionTwo);
            GameManager.CheckForUserWithdraw();
            xoGame.InitGame(boardSize, usersChoiceOfGameMode);
            xoGame.PlayGame();
        }

    }
}
