namespace B21_Ex02_01
{
    public class Constants
    {
        public const int MAX_BOARD_SIZE = 9;
        public const int MIN_BOARD_SIZE = 3;
        public const int GAME_MODE_OPTION1 = 1;
        public const int GAME_MODE_OPTION2 = 2;

    }

    public class Board
    {
        public char?[,] m_BoardMatrix;

        public Board(int i_SizeOfBoard)
        {
            m_BoardMatrix = new char?[i_SizeOfBoard, i_SizeOfBoard];
        }

        public void addShape(char shape, int row, int col)
        {
            m_BoardMatrix[row,col] = shape;
        }
    }
}
