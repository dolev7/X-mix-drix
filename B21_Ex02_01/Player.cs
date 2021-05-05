using System;

namespace B21_Ex02_01
{
    public partial class GameManager
    {
        public class Player
        {
            private char m_Symbol;
            private bool m_IsHuman;
            private int m_WinsCounter;
            public Player(char i_Symbol, bool i_IsHuman)
            {
                m_Symbol = i_Symbol;
                m_IsHuman = i_IsHuman;
                m_WinsCounter = 0;
            }
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
            public void MakeHumanMove(Board i_GameBoard)
            {
                int selectedRow = UI.GetRowFromPlayer(i_GameBoard.BoardSize);
                int selectedCol = UI.GetColFromPlayer(i_GameBoard.BoardSize);
                bool isSquareTaken = i_GameBoard.CheckIfSquareTaken(selectedRow, selectedCol);
                if (isSquareTaken)
                {
                    OutputManager.printMessageToUser("The Square you selected is taken, Select a valid Square");
                    MakeHumanMove(i_GameBoard);
                }
                else
                {
                    i_GameBoard.addShape(Symbol, selectedRow, selectedCol);
                }
            }   
            public void MakeComputerMove(Board i_GameBoard,Board.Square i_SelectedSquare)
            {
                int computerSelectedRow = i_SelectedSquare.m_Row;
                int computerSelectedCol = i_SelectedSquare.m_Col;
                i_GameBoard.addShape(Symbol, computerSelectedRow + 1, computerSelectedCol + 1);
            }

        }
    }
}
