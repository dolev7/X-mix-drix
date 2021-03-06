using System;

namespace B21_Ex02_01
{
    public class GameManager
    {
        public const int k_MaxBoardSize = 9;
        public const int k_MinBoardSize = 3;
        public const char k_SymbolOne = 'X';
        public const char k_SymbolTwo = 'O';
        public const string k_QuitSymbolOne = "Q";
        public const string k_QuitSymbolTwo = "q";

        public enum eGameModes
        {
            GameModeOptionOne = 1,
            GameModeOptionTwo
        }

        public static bool m_QSelected;
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private bool m_IsGameActive;
        private Board m_GameBoard;
        private int m_TurnCounter;

        public static void CheckForUserWithdraw()
        {
            if (m_QSelected)
            {
                OutputManager.PrintGameOver();
            }
        }

        public GameManager()
        {
            m_QSelected = false;
            m_PlayerOne = new Player(k_SymbolOne, true);
            m_PlayerTwo = new Player(k_SymbolTwo, true);
            m_IsGameActive = true;
            m_GameBoard = null;
            m_TurnCounter = 0;
        }

        public void InitGame(int i_BoardSize, int i_UsersChoiceOfGameMode) 
        {
            m_GameBoard = new Board(i_BoardSize);
            if (i_UsersChoiceOfGameMode == (int)eGameModes.GameModeOptionOne)
            {
                m_PlayerTwo.IsHuman = false;
            }

            OutputManager.DrawBoard(m_GameBoard);
        }

        public void PlayGame()
        {
            bool isTieGame = false;
            while (m_IsGameActive)
            {
                playTurn();
                bool playerHasWon = checkWin();
                if (playerHasWon || m_TurnCounter == (int)Math.Pow(m_GameBoard.BoardSize, 2) - 1)
                {
                    if (!playerHasWon)
                    {
                        isTieGame = true;
                    }

                    UpdateEndRoundResult(isTieGame);
                    StartOverMenu();
                }

                m_TurnCounter++;
            }
        }

        public void UpdateEndRoundResult(bool i_IsTieGame)
        {
            bool playerOneWon = false;
            if(!i_IsTieGame)
            {
                if(m_TurnCounter % 2 == 0)
                {
                    m_PlayerTwo.WinsCounter++;
                }
                else
                {
                    m_PlayerOne.WinsCounter++;
                    playerOneWon = true;
                }
            }

            OutputManager.PrintGameResult(i_IsTieGame, playerOneWon);
        }

        public void StartOverMenu()
        {
            OutputManager.PrintScoreBoard(m_PlayerOne.WinsCounter, m_PlayerTwo.WinsCounter);
            OutputManager.PrintUserRequestForAnotherRound();
            int usersChoice = InputManager.GetValidNumFromUser((int)eGameModes.GameModeOptionOne, (int)eGameModes.GameModeOptionTwo);
            if(usersChoice == (int)eGameModes.GameModeOptionOne)
            {
                m_GameBoard = new Board(m_GameBoard.BoardSize);
                m_TurnCounter = 0;
                OutputManager.DrawBoard(m_GameBoard);
                PlayGame();
            }
            else
            {
                OutputManager.PrintGameOver();
                m_IsGameActive = false;
            }
        }

        private Board.Square getComputerSmartChoice()
        {
            Board.Square selectedSquare = new Board.Square();
            for (int i = 0; i < m_GameBoard.BoardSize * m_GameBoard.BoardSize; i++)
            {
                Random random = new Random();
                int indexInList = random.Next(m_GameBoard.AvailableSquares.Count);
                selectedSquare = m_GameBoard.AvailableSquares[indexInList];
                m_GameBoard.AddShape(k_SymbolTwo, selectedSquare);
                bool isNewMoveMadeWin = checkWin();
                if(isNewMoveMadeWin)
                {
                    m_GameBoard.RemoveShape(k_SymbolTwo, selectedSquare);
                }
                else
                {
                    m_GameBoard.RemoveShape(k_SymbolTwo, selectedSquare);
                    break;
                }
            }

            return selectedSquare;
        }

        private void playTurn()
        {
            if(m_TurnCounter % 2 == 0)
            {
                m_PlayerOne.MakeHumanMove(m_GameBoard);
            }
            else
            {
                if(m_PlayerTwo.IsHuman)
                {
                    m_PlayerTwo.MakeHumanMove(m_GameBoard);
                }
                else
                {
                    Board.Square computerAiChoice = getComputerSmartChoice();
                    m_PlayerTwo.MakeComputerMove(m_GameBoard, computerAiChoice);
                }
            }

            if(m_QSelected)
            {
                m_QSelected = false;
                StartOverMenu();
            }
            else
            {
                OutputManager.DrawBoard(m_GameBoard);
            }
        }
        
        private bool checkWin()
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
