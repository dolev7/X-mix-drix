using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    public class XOGame
    {
        private const int MAX_BOARD_SIZE = 9;
        private const int MIN_BOARD_SIZE = 3;
        private const int GAME_MODE_OPTION1 = 1;
        private const int GAME_MODE_OPTION2 = 2;

        private bool m_IsGameActive;
        private bool? m_IsGameAgainstComputer;
        private Board m_Board;
        private int m_TurnCounter;
        private int m_Player1WinsCounter;
        private int m_Player2WinsCounter;

        public XOGame()
        {
            m_IsGameActive = true;
            m_IsGameAgainstComputer = null;
            m_Board = null;
            m_TurnCounter = 0;
            m_Player1WinsCounter = 0;
            m_Player2WinsCounter = 0;
    }
        public void InitGame()
        {
            UIMachine.printMessageToUser("Please enter size of XO matrix");
            int boardSize = UserInputValidator.getValidNumFromUser(MIN_BOARD_SIZE, MAX_BOARD_SIZE); 
             m_Board = new Board(boardSize);
            UIMachine.printMessageToUser
(@"Please choose the game mode:
For XO game against the computer - press 1
For XO game against a human player - press 2");
            int usersChoiceOfGameMode = UserInputValidator.getValidNumFromUser(GAME_MODE_OPTION1, GAME_MODE_OPTION2);
            if (usersChoiceOfGameMode == GAME_MODE_OPTION1)
            {
                m_IsGameAgainstComputer = true;
            }
            else
            {
                m_IsGameAgainstComputer = false;
            }
            UIMachine.drawBoard(m_Board);
        }
        public void PlayGame()
        {
            bool playerHasWon = false;
            while (m_IsGameActive)
            {
                if (m_IsGameAgainstComputer == true)
                {
                    ComputerPlayerTurn();
                }
                else
                {
                    HumanUserTurn();
                }
                playerHasWon = CheckWin();
                if(playerHasWon)
                {
                  
                    if(m_TurnCounter %2 == 0)
                    {
                        m_Player1WinsCounter++;
                        UIMachine.printMessageToUser("Player 1 has won");
                    }
                    else
                    {
                        m_Player2WinsCounter++;
                        UIMachine.printMessageToUser("Player 2 has won");
                    }
                    StartOverMenu();
                }
                m_TurnCounter++;
            }
        }
        public void StartOverMenu()
        {

            Console.WriteLine
(@"Scoreboard:
Player 1 : {0}
Player 2 : {1}", m_Player1WinsCounter,m_Player2WinsCounter);
            UIMachine.printMessageToUser
(@"Do you want to play another round?:
Yes - press 1
No - press 2");
            int usersChoice = UserInputValidator.getValidNumFromUser(GAME_MODE_OPTION1, GAME_MODE_OPTION2);
            if(usersChoice == GAME_MODE_OPTION1)
            {
               
                m_Board = new Board(m_Board.m_BoardSize);
                m_TurnCounter = 0;
                UIMachine.drawBoard(m_Board);
                PlayGame();
            }
            else
            {
                UIMachine.printMessageToUser("Bye Bye :-)");      
            }
        }
        private void HumanUserTurn()
        {
            char symbol;
            if (m_TurnCounter%2 == 0)
            {
                symbol = 'X';
            }
            else
            {
                symbol = 'O';
            }
            UIMachine.printMessageToUser("Please enter row number");
            int selectedRow = UserInputValidator.getValidNumFromUser(1, m_Board.m_BoardSize);
            UIMachine.printMessageToUser("Please enter col number");
            int selectedCol = UserInputValidator.getValidNumFromUser(1, m_Board.m_BoardSize);
            bool isSquareTaken = m_Board.CheckIfSquareTaken(selectedRow, selectedCol);
            if (isSquareTaken)
            {
                UIMachine.printMessageToUser("The square you selected is taken, Select a valid square");
                HumanUserTurn();
            }
            else
            {
                m_Board.addShape(symbol, selectedRow, selectedCol);
                UIMachine.drawBoard(m_Board);
            }
        }

        private void ComputerPlayerTurn()
        {
            // need to check how to randomize 
        }

        private bool CheckWin()
        {
            bool hasPlayerWon = false;
            for (int i = 1; i <= m_Board.m_BoardSize; i++)
            {
                for (int j = 1; j <= m_Board.m_BoardSize; j++)
                {
                    if (m_Board.CheckForDownSequence(i, j) || m_Board.CheckForRightSequence(i, j) || m_Board.CheckForRightDiagonalSequence(i, j) || m_Board.CheckForLeftDiagonalSequence(i, j))
                    {
                        hasPlayerWon = true;
                        break;
                    }
                }
            }

            return hasPlayerWon;
        }



    }

}
