using System;

namespace Model
{
    public class Board
    {
        public static string[,] DrawingBoard()           //棋盘模型
        {
            string[,] Board = new string[19, 17];
            Console.Clear();

            Board[0, 0] = "┏-";
            Board[18, 0] = "┗-";
            Board[0, 16] = "┓";
            Board[18, 16] = "┛";

            for (int i = 1; i < 18; i++)
            {
                if (i % 2 == 0)
                {
                    Board[i, 0] = "┣-";
                    Board[i, 16] = "┫ ";
                }
                else
                {
                    Board[i, 0] = "┃ ";
                    Board[i, 16] = "┃ ";
                }
            }

            for (int j = 1; j < 16; j++)
            {
                Board[0, j] = "—";
                Board[10, j] = "--";
                Board[8, j] = "--";
                Board[18, j] = "—";
            }

            for (int k = 1; k < 16; k++)
            {


                Board[1, k] = "┃ ";
                Board[2, k] = "╋-";
                Board[3, k] = "┃ ";
                Board[4, k] = "╋-";
                Board[5, k] = "┃ ";
                Board[6, k] = "╋-";
                Board[7, k] = "┃ ";
                Board[9, k] = "  ";
                Board[11, k] = "┃ ";
                Board[12, k] = "╋-";
                Board[13, k] = "┃ ";
                Board[14, k] = "╋-";
                Board[15, k] = "┃ ";
                Board[16, k] = "╋-";
                Board[17, k] = "┃ ";

                if (k % 2 != 0)
                {
                    Board[1, k] = "  ";
                    Board[2, k] = "  ";
                    Board[3, k] = "  ";
                    Board[4, k] = "  ";
                    Board[5, k] = "  ";
                    Board[6, k] = "  ";
                    Board[7, k] = "  ";
                    Board[9, k] = "  ";
                    Board[11, k] = "  ";
                    Board[12, k] = "  ";
                    Board[13, k] = "  ";
                    Board[14, k] = "  ";
                    Board[15, k] = "  ";
                    Board[16, k] = "  ";
                    Board[17, k] = "  ";
                }
            }

            Board[1, 6] = "┃";
            Board[3, 6] = "┃";
            Board[15, 6] = "┃";
            Board[17, 6] = "┃";
            Board[9, 5] = "楚";
            Board[9, 6] = "河";
            Board[9, 10] = "汉";
            Board[9, 11] = "界";
            Board[1, 8] = "╲┃╱";
            Board[3, 8] = "╱┃╲";
            Board[15, 8] = "╲┃╱";
            Board[17, 8] = "╱┃╲";

            return Board;
        }
    }
}