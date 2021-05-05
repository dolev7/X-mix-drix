using System.Collections.Generic;

namespace B21_Ex02_01
{
    public class Board
    {
        private char?[,] m_BoardMatrix;
        private readonly int m_BoardSize;
        private List<Square> m_AvailableSqaures;

        public List<Square> AvailableSquares
        {
            get
            {
                return m_AvailableSqaures;
            }
        }

        public struct Square
        {
            public int m_Row;
            public int m_Col;
        }

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }
        }

        public char?[,] BoardMatrix
        {
            get
            {
                return m_BoardMatrix;
            }
        }

        public Board(int i_SizeOfBoard)
        {
            m_BoardSize = i_SizeOfBoard;
            m_BoardMatrix = new char?[i_SizeOfBoard, i_SizeOfBoard];
            m_AvailableSqaures = new List<Square>();
            for (int i = 1; i <= m_BoardSize; i++)
            {
                for (int j = 1; j <= m_BoardSize; j++)
                {
                    m_AvailableSqaures.Add(new Square() { m_Row = i, m_Col = j });
                }
            }
        }

        public void addShape(char i_Shape, Square i_AddedSquare)
        {
            m_BoardMatrix[i_AddedSquare.m_Row - 1, i_AddedSquare.m_Col - 1] = i_Shape;
            m_AvailableSqaures.Remove(new Square() { m_Row = i_AddedSquare.m_Row , m_Col = i_AddedSquare.m_Col });
        }
        public void removeShape(char i_Shape, Square i_AddedSquare)
        {
            m_BoardMatrix[i_AddedSquare.m_Row - 1, i_AddedSquare.m_Col - 1] = null;
            m_AvailableSqaures.Add(new Square() { m_Row = i_AddedSquare.m_Row , m_Col = i_AddedSquare.m_Col });
        }

        public bool CheckIfSquareTaken(Square i_SquareToCheck)
        {
            return m_BoardMatrix[i_SquareToCheck.m_Row - 1, i_SquareToCheck.m_Col - 1] != null;
        }

        public bool CheckForRightSequence(int i_RowToCheck, int i_ColToCheck)
        {
            char? symbolToCheck = m_BoardMatrix[i_RowToCheck - 1, i_ColToCheck - 1];
            bool isSequence = true;
            if (i_ColToCheck - 1 > 0 || symbolToCheck == null)
            {
                isSequence = false;
            }
            else
            {
                for (int i = 1; i < m_BoardSize; i++)
                {
                    if (m_BoardMatrix[i_RowToCheck - 1, i] != symbolToCheck)
                    {
                        isSequence = false;
                        break;
                    }
                }
            }

            return isSequence;
        }

        public bool CheckForDownSequence(int i_RowToCheck, int i_ColToCheck)
        {
            char? symbolToCheck = m_BoardMatrix[i_RowToCheck - 1, i_ColToCheck - 1];
            bool isSequence = true;
            if (i_RowToCheck - 1 > 0 || symbolToCheck == null)
            {
                isSequence = false;
            }
            else
            {
                for (int i = 1; i < m_BoardSize; i++)
                {
                    if (m_BoardMatrix[i, i_ColToCheck - 1] != symbolToCheck)
                    {
                        isSequence = false;
                        break;
                    }
                }
            }

            return isSequence;
        }

        public bool CheckForRightDiagonalSequence(int i_RowToCheck, int i_ColToCheck)
        {
            i_ColToCheck--;
            i_RowToCheck--;
            char? symbolToCheck = m_BoardMatrix[i_RowToCheck, i_ColToCheck];
            bool isSequence = true;
            if (i_RowToCheck > 0 || i_ColToCheck > 0 || symbolToCheck == null)
            {
                isSequence = false;
            }
            else
            {
                for (int i = 1; i < m_BoardSize; i++)
                {
                    if (m_BoardMatrix[i_RowToCheck + i, i_ColToCheck + i] != symbolToCheck)
                    {
                        isSequence = false;
                        break;
                    }
                }
            }
            return isSequence;
        }

        public bool CheckForLeftDiagonalSequence(int i_RowToCheck, int i_ColToCheck)
        {
            i_RowToCheck--;
            i_ColToCheck--;
            char? symbolToCheck = m_BoardMatrix[i_RowToCheck, i_ColToCheck ];
            bool isSequence = true;
            if (i_RowToCheck > 0 || i_ColToCheck < m_BoardSize - 1 || symbolToCheck == null)
            {
                isSequence = false;
            }
            else
            {
                for (int i = 1; i < m_BoardSize; i++)
                {
                    if (m_BoardMatrix[i_RowToCheck + i, i_ColToCheck - i] != symbolToCheck)
                    {
                        isSequence = false;
                        break;
                    }
                }
            }

            return isSequence;
        }
    }
}
