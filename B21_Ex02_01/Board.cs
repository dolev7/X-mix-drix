namespace B21_Ex02_01
{
    public class Board
    {
        public char?[,] m_BoardMatrix; //need to change to private 
        public int m_BoardSize;

        public Board(int i_SizeOfBoard)
        {
            m_BoardSize = i_SizeOfBoard;
            m_BoardMatrix = new char?[i_SizeOfBoard, i_SizeOfBoard];
        }

        public void addShape(char shape, int row, int col)
        {
            m_BoardMatrix[row,col] = shape;
        }
    }
}
