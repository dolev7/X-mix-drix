﻿using System;
using System.Collections.Generic;
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
            private int m_PlayerWinsCounter;

            public bool IsHuman
            {
                get; set;
            }

            public Player(char i_Symbol, bool i_IsHuman)
            {
                m_Symbol = i_Symbol;
                m_IsHuman = i_IsHuman;
                m_PlayerWinsCounter = 0;
            }
        }

        private const int k_MaxBoardSize = 9;
        private const int k_MinBoardSize = 3;
        private const int k_GameModeOptionOne = 1;
        private const int k_GameModeOptionTwo = 2;

        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private bool m_IsGameActive;
        private bool? m_IsGameAgainstComputer;
        private Board m_Board;
        private int m_TurnCounter;
        private int m_Player1WinsCounter;
        private int m_Player2WinsCounter;
        
        public XOGame()
        {
            m_PlayerOne = new Player('X', false);
            m_PlayerTwo = new Player('O', false);
            m_IsGameActive = true;
            m_Board = null;
            m_TurnCounter = 0;
        }

        public void InitGame()
        {
            UIMachine.printMessageToUser("Please enter size of XO matrix");
            int boardSize = UserInputValidator.getValidNumFromUser(k_MinBoardSize, k_MaxBoardSize); 
             m_Board = new Board(boardSize);
            UIMachine.printMessageToUser
(@"Please choose the game mode:
For XO game against the computer - press 1
For XO game against a human player - press 2");
            int usersChoiceOfGameMode = UserInputValidator.getValidNumFromUser(k_GameModeOptionOne, k_GameModeOptionTwo);
            if (usersChoiceOfGameMode == k_GameModeOptionOne)
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
            while (m_IsGameActive)
            {
                bool playerHasWon = false;
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
                    if(m_TurnCounter % 2 == 0)
                    {
                        m_Player2WinsCounter++;
                        UIMachine.printMessageToUser("Player 2 has won");
                    }
                    else
                    {
                        m_Player1WinsCounter++;
                        UIMachine.printMessageToUser("Player 1 has won");
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
Player 2 : {1}",
m_Player1WinsCounter,
m_Player2WinsCounter);
            UIMachine.printMessageToUser
(@"Do you want to play another round?:
Yes - press 1
No - press 2");
            int usersChoice = UserInputValidator.getValidNumFromUser(k_GameModeOptionOne, k_GameModeOptionTwo);
            if(usersChoice == k_GameModeOptionOne)
            {
                m_Board = new Board(m_Board.m_BoardSize);
                m_TurnCounter = 0;
                UIMachine.drawBoard(m_Board);
                PlayGame();
            }
            else
            {
                UIMachine.printMessageToUser("Bye Bye :-)");
                m_IsGameActive = false;
            }
        }

        private void HumanUserTurn()
        {
            char symbol;
            if (m_TurnCounter % 2 == 0)
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
