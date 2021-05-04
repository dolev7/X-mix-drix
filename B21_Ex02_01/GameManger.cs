using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    public partial class GameManger
    {
        public const int k_MaxBoardSize = 9;
        public const int k_MinBoardSize = 3;
        public const int k_GameModeOptionOne = 1;
        public const int k_GameModeOptionTwo = 2;
        public const char k_SymbolOne = 'X';
        public const char k_SymbolTwo = 'O';

        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private bool m_IsGameActive;
        private Board m_GameBoard;
        private int m_TurnCounter;
        public int Player1WinsCounter
        {
            get
            { 
                return m_PlayerOne.WinsCounter;
            }
        }
        public int Player2WinsCounter
        {
            get
            {
                return m_PlayerTwo.WinsCounter;
            }
                  
        }
        public GameManger()
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
        public bool IsGameActive
        {
            get { return m_IsGameActive; }
        }

        public void InitGame(int i_BoardSize, int i_usersChoiceOfGameMode)
        {
            m_GameBoard = new Board(i_BoardSize);
            if (i_usersChoiceOfGameMode == k_GameModeOptionOne)
            {
                m_PlayerTwo.IsHuman = false;
            }
        }

        public int WhichPlayerTurn()
        {
            int roundWinnerPlayerNumber;
            if (m_TurnCounter % 2 == 0)
            {
                roundWinnerPlayerNumber = k_GameModeOptionTwo;
            }
            else
            {
                roundWinnerPlayerNumber = k_GameModeOptionOne;
            }
            return roundWinnerPlayerNumber;
        }
        public void UpdateVictory(int i_PlayerNumber)
        {
            if (i_PlayerNumber  == k_GameModeOptionOne)
            {
                m_PlayerTwo.WinsCounter++;
            }
            else
            {
                m_PlayerOne.WinsCounter++;
            }
        }

        public void addShapeToGame(int i_Row, int i_Col)
        {
            m_GameBoard.addShape(i_CurrentPlayer.Symbol, selectedRow, selectedCol);
        }

    
        public void StartOverMenu()
        {
                m_GameBoard = new Board(m_GameBoard.BoardSize);
                m_TurnCounter = 0;
        }

        public void StopGame()
        {
            m_IsGameActive = false;
        }



        private void ComputerPlayerTurn(Player i_CurrentPlayer)
        {
            // to implement 
        }

        public bool IsHumanTurn()
        {
            bool isHuman = false;
            if (m_TurnCounter % 2 == 0)
            {
                isHuman = true;
            }
            else
            {
                if (m_PlayerTwo.IsHuman)
                {
                    isHuman = true;
                }
            }

            return isHuman;
        }
        public void PlayTurn(bool i_IsHuman)
        {
            m_TurnCounter++;
            if (m_TurnCounter % 2 == 0)
            {
                HumanUserTurn(m_PlayerOne);
            }
            else
            {
                if (m_PlayerTwo.IsHuman)
                {
                    HumanUserTurn(m_PlayerTwo);
                }
                else
                {
                    ComputerPlayerTurn(m_PlayerTwo);
                }
            }
        }


        public bool CheckWin()
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
