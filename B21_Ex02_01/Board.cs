namespace B21_Ex02_01
{
    public class Board
    {
        private char?[,] m_BoardMatrix;
        private readonly int m_BoardSize;
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
        }

        public void addShape(char shape, int row, int col)
        {
            m_BoardMatrix[row - 1, col - 1] = shape;
        }

        public bool CheckIfSquareTaken(int i_RowToCheck, int i_ColToCheck)
        {
            return m_BoardMatrix[i_RowToCheck - 1, i_ColToCheck - 1] != null;
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
