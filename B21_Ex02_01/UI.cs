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

        private XOGameManger m_Xogame;
        public UI()
        {
            m_Xogame = new XOGameManger();
        }
        public void StartGame()
        {
            IOManager.printMessageToUser("Please enter size of XO matrix");
            int boardSize = IOManager.getValidNumFromUser(k_MinBoardSize, k_MaxBoardSize);
            IOManager.printMessageToUser
(@"Please choose the game mode:
For XO game against the computer - press 1
For XO game against a human player - press 2");
            int usersChoiceOfGameMode = IOManager.getValidNumFromUser(k_GameModeOptionOne, k_GameModeOptionTwo);
            m_Xogame.InitGame(boardSize, usersChoiceOfGameMode);

            BoardDrawer.drawBoard(m_Xogame.GameBoard);
        }
        public void PlayGame()
        {
            while (m_Xogame.IsGameActive)
            {
                int playerNumber = m_Xogame.WhichPlayerTurn();
                bool playerHasWon = false;
                PlayTurn(playerNumber);
                playerHasWon = m_Xogame.CheckWin();
                if (playerHasWon)
                {
                    EndRound(playerNumber);
                }
            }
        }
        public void EndRound(int i_PlayerNumber)
        {
            m_Xogame.UpdateVictory(i_PlayerNumber);
            IOManager.printMessageToUser("The winner in this round is " + i_PlayerNumber);
            Console.WriteLine
(@"Scoreboard:
Player 1 : {0}
Player 2 : {1}",
m_Xogame.Player1WinsCounter,
m_Xogame.Player2WinsCounter);
            IOManager.printMessageToUser
(@"Do you want to play another round?:
Yes - press 1
No - press 2");
            int usersChoice = IOManager.getValidNumFromUser(k_GameModeOptionOne, k_GameModeOptionTwo);
            if (usersChoice == k_GameModeOptionOne)
            {
                m_Xogame.StartOverMenu();
                BoardDrawer.drawBoard(m_Xogame.GameBoard);
            }
            else
            {
                m_Xogame.StopGame();
                IOManager.printMessageToUser("Bye Bye :-)");
            }

        }
        private void PlayTurn(int i_playerNumber)
        {
            bool isHuman = m_Xogame.IsHumanTurn();
            if (isHuman)
            {
                HumanUserTurn();
            }
            else
            {
                // need to implement computer 
            }
        }
        private void HumanUserTurn()
        {
            IOManager.printMessageToUser("Please enter row number");
            int selectedRow = IOManager.getValidNumFromUser(1, m_Xogame.GameBoard.BoardSize);
            IOManager.printMessageToUser("Please enter col number");
            int selectedCol = IOManager.getValidNumFromUser(1, m_Xogame.GameBoard.BoardSize);
            bool isSquareTaken = m_Xogame.GameBoard.CheckIfSquareTaken(selectedRow, selectedCol);
            if (isSquareTaken)
            {
                IOManager.printMessageToUser("The square you selected is taken, Select a valid square");
                HumanUserTurn();
            }
            else
            {
                m_Xogame.addShapeToGame(selectedRow, selectedCol);
                BoardDrawer.drawBoard(m_Xogame.GameBoard);
            }
        }
    }
}

