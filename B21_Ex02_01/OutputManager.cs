using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    public class OutputManager
    {

        public static void printBoardLines(StringBuilder i_Message)
        {
            Console.WriteLine(i_Message);
        }

        public static void printGameResult(bool i_IsTieGame, bool i_playerOneWon)
        {
            if (i_IsTieGame)
            {
                Console.WriteLine("Game has ended with tie result");
            }
            else if (i_playerOneWon)
            {
                Console.WriteLine("Player 1 wins this round");
            }
            else
            {
                Console.WriteLine("Player 2 wins this round");
            }
        }

        public static void PrintUserRequestForAnotherRound()
        {
            Console.WriteLine(@"Do you want to play another round?:
Yes - press 1
No - press 2");
        }

        public static void PrintScoreBoard(int i_PlayerOneWinsCounter, int i_PlayerTwoWinsCounter)
        {
            Console.WriteLine(@"Scoreboard:
Player 1 : {0}
Player 2 : {1}",
i_PlayerOneWinsCounter,
i_PlayerTwoWinsCounter);
        }
        public static void PrintInvalidSquareError()
        {
            Console.WriteLine("The Square you selected is taken, Select a valid Square");
        }

        public static void PrintInvalidNumberError()
        {
            Console.WriteLine("Please enter a correct number");
        }

        public static void PrintGameOver()
        {
            Console.WriteLine("Bye Bye :-)");
        }

        public static void PrintRequestForBoardSize()
        {
            Console.WriteLine("Please enter size of XO board");
        }

        public static void PrintRequestForRow()
        {
            Console.WriteLine("Please enter row number");
        }

        public static void PrintRequestForCol()
        {
            Console.WriteLine("Please enter column number");
        }

        public static void printRequestForGameMode()
        {
            Console.WriteLine(@"Please choose the game mode:
For XO game against the computer - press 1
For XO game against a human player - press 2");
        }
        public static void drawBoard(Board i_GameBoard)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            int sizeOfMatrix = i_GameBoard.BoardSize;
            drawUpperBounds(sizeOfMatrix);
            for (int i = 1; i <= sizeOfMatrix; i++)
            {
                drawCurrentLine(i_GameBoard, i, sizeOfMatrix);
                drawSeparator(sizeOfMatrix);
            }
        }

        private static void drawUpperBounds(int i_MatrixCols)
        {
            int lengthToPrint = (i_MatrixCols * 4) + 1;
            StringBuilder currentLine = new StringBuilder(lengthToPrint);
            currentLine.Append("  ");
            for (int i = 1; i <= i_MatrixCols; i++)
            {
                currentLine.Append(i + "   ");
            }

            printBoardLines(currentLine);
        }

        private static void drawCurrentLine(Board i_GameBoard, int i_CurrentLineNumber, int i_MatrixRows)
        {
            int lengthToPrint = (i_MatrixRows * 4) + 1;
            StringBuilder currentLine = new StringBuilder(lengthToPrint);
            currentLine.Append(i_CurrentLineNumber + "|");
            for (int i = 1; i <= i_MatrixRows; i++)
            {
                currentLine.Append(" ");
                if (i_GameBoard.BoardMatrix[i_CurrentLineNumber - 1, i - 1] == null)
                {
                    currentLine.Append(" ");
                }
                else
                {
                    currentLine.Append(i_GameBoard.BoardMatrix[i_CurrentLineNumber - 1, i - 1]);
                }

                currentLine.Append(" |");
            }

            printBoardLines(currentLine);
        }

        private static void drawSeparator(int i_LengthOfLine)
        {
            int lengthToPrint = (i_LengthOfLine * 4) + 1;
            StringBuilder currentLine = new StringBuilder(lengthToPrint);
            currentLine.Append(" ");
            for (int i = 1; i <= lengthToPrint; i++)
            {
                currentLine.Append("=");
            }

           printBoardLines(currentLine);
        }
    }
}
