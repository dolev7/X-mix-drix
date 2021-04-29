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

        public XOGame()
        {
            m_IsGameActive = true;
            m_IsGameAgainstComputer = null;
            m_Board = null;
        }
        public void initGame()
        {
            UIMachine.printMessageToUser("Please enter size of XO matrix");
            int boardSize = UserInputValidator.getValidNumFromUser(MIN_BOARD_SIZE, MAX_BOARD_SIZE); 
             m_Board = new Board(boardSize);
            UIMachine.printMessageToUser("Please choose the game mode");
            UIMachine.printMessageToUser("For XO game against the computer - press 1, For XO game against a human player - press 2");
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
        public void playGame()
        {
            while (m_IsGameActive)
            {
                UIMachine.printMessageToUser("Please enter row number");
                int selectedRow = UserInputValidator.getValidNumFromUser(1, m_Board.m_BoardSize);
                UIMachine.printMessageToUser("Please enter col number");
                int selectedCol = UserInputValidator.getValidNumFromUser(1, m_Board.m_BoardSize);
                m_Board.addShape('x', selectedRow - 1, selectedCol - 1);
                UIMachine.drawBoard(m_Board);
            }
        }
       

    }

}
