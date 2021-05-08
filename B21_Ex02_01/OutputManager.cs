using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    public class OutputManager
    {
        private static void printBoardLines(StringBuilder i_Lines)
        {
            Console.WriteLine(i_Lines);
        }

        private static void printMessageToUser(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        public static void PrintGameResult(bool i_IsTieGame, bool i_playerOneWon)
        {
            if (i_IsTieGame)
            {
                printMessageToUser("Game has ended with tie result");
            }
            else if (i_playerOneWon)
            {
                printMessageToUser("Player 1 wins this round");
            }
            else
            {
                printMessageToUser("Player 2 wins this round");
            }
        }

        public static void PrintUserRequestForAnotherRound()
        {
            printMessageToUser(@"Do you want to play another round?:
Yes - press 1
No - press 2");
        }

        public static void PrintScoreBoard(int i_PlayerOneWinsCounter, int i_PlayerTwoWinsCounter)
        { 
        Console.WriteLine(
        @"Scoreboard:
Player 1 : {0}
Player 2 : {1}",
i_PlayerOneWinsCounter,
i_PlayerTwoWinsCounter);
        }

        public static void PrintInvalidSquareError()
        {
            printMessageToUser("The Square you selected is taken, Select a valid Square");
        }

        public static void PrintInvalidNumberError()
        {
            printMessageToUser("Please enter a correct number");
        }

        public static void PrintGameOver()
        {
            printMessageToUser("Bye Bye :-)");
            Environment.Exit(0);
        }

        public static void PrintRequestForBoardSize()
        {
            printMessageToUser("Please enter size of XO board between 3 and 9");
        }

        public static void PrintRequestForRow()
        {
            printMessageToUser("Please enter row number");
        }

        public static void PrintRequestForCol()
        {
            printMessageToUser("Please enter column number");
        }

        public static void PrintRequestForGameMode()
        {
            printMessageToUser(@"Please choose the game mode:
For XO game against the computer - press 1
For XO game against a human player - press 2");
        }

        public static void DrawBoard(Board i_GameBoard)
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
