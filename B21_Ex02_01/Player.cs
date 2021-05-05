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
                Board.Square selectedSquare = InputManager.GetSquareFromPlayer(i_GameBoard.BoardSize);
                bool isSquareTaken = i_GameBoard.CheckIfSquareTaken(selectedSquare);
                if (isSquareTaken)
                {
                    OutputManager.PrintInvalidSquareError();
                    MakeHumanMove(i_GameBoard);
                }
                else
                {
                    i_GameBoard.addShape(Symbol, selectedSquare);
                }
            }   
            public void MakeComputerMove(Board i_GameBoard,Board.Square i_SelectedSquare)
            {
                i_GameBoard.addShape(Symbol, i_SelectedSquare);
            }

        }
    }
}
