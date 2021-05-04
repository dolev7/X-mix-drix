using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    public class XOGame
    {
        public class Player
        {
            private char m_Symbol;
            private bool m_IsHuman;
            private int m_WinsCounter;

            public bool IsHuman
            {
                get
                {
                    return m_IsHuman;
                }
                set
                {
                    m_IsHuman = value;
                }
            }
            public char Symbol
            {
                get
                {
                    return m_Symbol;
                }
            }
            public int WinsCounter
            {
                get
                {
                    return m_WinsCounter;
                }
                set
                {
                    m_WinsCounter = value;
                }
            }

            public Player(char i_Symbol, bool i_IsHuman)
            {
                m_Symbol = i_Symbol;
                m_IsHuman = i_IsHuman;
                m_WinsCounter = 0;
            }
        }

        private const int k_MaxBoardSize = 9;
        private const int k_MinBoardSize = 3;
        private const int k_GameModeOptionOne = 1;
        private const int k_GameModeOptionTwo = 2;
        private const char k_SymbolOne = 'X';
        private const char k_SymbolTwo = 'O';

        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private bool m_IsGameActive;
        private Board m_GameBoard;
        private int m_TurnCounter;

        public XOGame()
        {
            m_PlayerOne = new Player(k_SymbolOne, true);
            m_PlayerTwo = new Player(k_SymbolTwo, true);
            m_IsGameActive = true;
            m_GameBoard = null;
            m_TurnCounter = 0;
        }

        public Board GameBoard
        {
            get
            {
                return m_GameBoard;
            }
        }
        public void InitGame()
        {
            UIMachine.printMessageToUser("Please enter size of XO matrix");
            int boardSize = UserInputValidator.getValidNumFromUser(k_MinBoardSize, k_MaxBoardSize); 
             m_GameBoard = new Board(boardSize);
            UIMachine.printMessageToUser
(@"Please choose the game mode:
For XO game against the computer - press 1
For XO game against a human player - press 2");
            int usersChoiceOfGameMode = UserInputValidator.getValidNumFromUser(k_GameModeOptionOne, k_GameModeOptionTwo);
            if (usersChoiceOfGameMode == k_GameModeOptionOne)
            {
                m_PlayerTwo.IsHuman = false;
            }

            UIMachine.drawBoard(m_GameBoard);
        }

        public void PlayGame()
        {
            while (m_IsGameActive)
            {
                bool playerHasWon = false;
                PlayTurn();
                playerHasWon = CheckWin();
                if(playerHasWon)
                {
                    UpdateVictory();
                    StartOverMenu();
                }
                m_TurnCounter++;
            }
        }

        public void UpdateVictory()
        {
            if (m_TurnCounter % 2 == 0)
            {
                m_PlayerTwo.WinsCounter++;
                UIMachine.printMessageToUser("Player 2 has won");
            }
            else
            {
                m_PlayerOne.WinsCounter++;
                UIMachine.printMessageToUser("Player 1 has won");
            }
        }
        private void HumanUserTurn(Player i_CurrentPlayer)
        {
            UIMachine.printMessageToUser("Please enter row number");
            int selectedRow = UserInputValidator.getValidNumFromUser(1, m_GameBoard.BoardSize);
            UIMachine.printMessageToUser("Please enter col number");
            int selectedCol = UserInputValidator.getValidNumFromUser(1, m_GameBoard.BoardSize);
            bool isSquareTaken = m_GameBoard.CheckIfSquareTaken(selectedRow, selectedCol);
            if (isSquareTaken)
            {
                UIMachine.printMessageToUser("The square you selected is taken, Select a valid square");
                HumanUserTurn(i_CurrentPlayer);
            }
            else
            {
                m_GameBoard.addShape(i_CurrentPlayer.Symbol, selectedRow, selectedCol);
                UIMachine.drawBoard(m_GameBoard);
            }
        }
        public void StartOverMenu()
        {
            Console.WriteLine
            (@"Scoreboard:
Player 1 : {0}
Player 2 : {1}",
m_PlayerOne.WinsCounter,
m_PlayerTwo.WinsCounter);
            UIMachine.printMessageToUser
(@"Do you want to play another round?:
Yes - press 1
No - press 2");
            int usersChoice = UserInputValidator.getValidNumFromUser(k_GameModeOptionOne, k_GameModeOptionTwo);
            if(usersChoice == k_GameModeOptionOne)
            {
                m_GameBoard = new Board(m_GameBoard.BoardSize);
                m_TurnCounter = 0;
                UIMachine.drawBoard(m_GameBoard);
                PlayGame();
            }
            else
            {
                UIMachine.printMessageToUser("Bye Bye :-)");
                m_IsGameActive = false;
            }
        }
        

        private void ComputerPlayerTurn(Player i_CurrentPlayer)
        {
            // to implement 
        }
        private void PlayTurn()
        {
            if(m_TurnCounter % 2 == 0)
            {
                HumanUserTurn(m_PlayerOne);
            }
            else
            {
                if(m_PlayerTwo.IsHuman)
                {
                    HumanUserTurn(m_PlayerTwo);
                }
                else
                {
                    ComputerPlayerTurn(m_PlayerTwo);
                }
            }
        }

        private bool CheckWin()
        {
            bool hasPlayerWon = false;
            for (int i = 1; i <= m_GameBoard.BoardSize; i++)
            {
                for (int j = 1; j <= m_GameBoard.BoardSize; j++)
                {
                    if (m_GameBoard.CheckForDownSequence(i, j) || m_GameBoard.CheckForRightSequence(i, j) || m_GameBoard.CheckForRightDiagonalSequence(i, j) || m_GameBoard.CheckForLeftDiagonalSequence(i, j))
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
