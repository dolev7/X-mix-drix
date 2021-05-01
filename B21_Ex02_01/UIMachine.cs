﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02_01
{
    class UIMachine
    {
        public static void printMessageToUser(string i_Message)
        {
            Console.WriteLine(i_Message);
        }
        public static void printMessageToUser(StringBuilder i_Message)
        {
            Console.WriteLine(i_Message);
        }
        public static string getDataFromUser()
        {
            string userData;
            userData = Console.ReadLine();

            return userData;
        }
        public static void drawBoard(Board i_GameBoard)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            int sizeOfMatrix = i_GameBoard.m_BoardSize;
            drawUpperBounds(sizeOfMatrix);
            for (int i = 1; i <= sizeOfMatrix; i++)
            {
                drawCurrentLine(i_GameBoard, i, sizeOfMatrix);
                drawSeparator(sizeOfMatrix);
            }
        }

        private static void drawUpperBounds(int i_MatrixCols)
        {
            int lengthToPrint = i_MatrixCols * 4 + 1;
            StringBuilder currentLine = new StringBuilder(lengthToPrint);
            currentLine.Append("  ");
            for (int i = 1; i <= i_MatrixCols; i++)
            {
                currentLine.Append(i + "   ");
            }
            printMessageToUser(currentLine);
        }

        private static void drawCurrentLine(Board i_GameBoard, int i_CurrentLineNumber, int i_MatrixRows)
        {
            int lengthToPrint = i_MatrixRows * 4 + 1;
            StringBuilder currentLine = new StringBuilder(lengthToPrint);
            currentLine.Append(i_CurrentLineNumber + "|");
            for (int i = 1; i <= i_MatrixRows; i++)
            {
                currentLine.Append(" ");
                if (i_GameBoard.m_BoardMatrix[i_CurrentLineNumber - 1, i - 1] == null)
                {
                    currentLine.Append(" ");
                }
                else
                {
                    currentLine.Append(i_GameBoard.m_BoardMatrix[i_CurrentLineNumber - 1, i - 1]);
                }

                currentLine.Append(" |");

            }
            printMessageToUser(currentLine);

        }

        private static void drawSeparator(int i_LengthOfLine)
        {
            int lengthToPrint = i_LengthOfLine * 4 + 1;
            StringBuilder currentLine = new StringBuilder(lengthToPrint);
            currentLine.Append(" ");
            for (int i = 1; i <= lengthToPrint; i++)
            {
                currentLine.Append("=");
            }
           printMessageToUser(currentLine);

        }

    }
}
