using System;

namespace B21_Ex02_01
{
        public class Player
        {
            private readonly char r_Symbol;
            private bool m_IsHuman;
            private int m_WinsCounter;

            public Player(char i_Symbol, bool i_IsHuman)
            {
                r_Symbol = i_Symbol;
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
                    return r_Symbol;
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
                Board.Square selectedSquare = new Board.Square();
                InputManager.GetSquareFromPlayer(i_GameBoard.BoardSize, ref selectedSquare);
                if(!GameManager.m_QSelected)
                {
                    bool isSquareTaken = i_GameBoard.CheckIfSquareTaken(selectedSquare);
                    if(isSquareTaken)
                    {
                        OutputManager.PrintInvalidSquareError();
                        MakeHumanMove(i_GameBoard);
                    }
                    else
                    {
                        i_GameBoard.AddShape(Symbol, selectedSquare);
                    }
                }
            }   

            public void MakeComputerMove(Board i_GameBoard, Board.Square i_SelectedSquare)
            {
                i_GameBoard.AddShape(Symbol, i_SelectedSquare);
            }
        }
    }