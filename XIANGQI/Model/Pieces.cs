using System;

namespace Model
{
    public class ProMod: Chess
    {
        static void Main(string[] args)
        {
        }


        public string Word(Chess[,] Matrix, string str, int i, int j)      //打印每种棋子名字
        {
            switch (Matrix[i, j].side)
            {
                case Chess.Player.red:
                    switch (Matrix[i, j].type)
                    {
                        case Chess.Piecetype.che:
                            str = "車";
                            return str;
                        case Chess.Piecetype.ma:
                            str = "马";
                            return str;
                        case Chess.Piecetype.xiang:
                            str = "象";
                            return str;
                        case Chess.Piecetype.shi:
                            str = "仕";
                            return str;
                        case Chess.Piecetype.jiang:
                            str = "帅";
                            return str;
                        case Chess.Piecetype.pao:
                            str = "炮";
                            return str;
                        case Chess.Piecetype.bing:
                            str = "兵";
                            return str;
                    }
                    return str;

                case Chess.Player.black:
                    switch (Matrix[i, j].type)
                    {
                        case Chess.Piecetype.che:
                            str = "车";
                            return str;
                        case Chess.Piecetype.ma:
                            str = "马";
                            return str;
                        case Chess.Piecetype.xiang:
                            str = "相";
                            return str;
                        case Chess.Piecetype.shi:
                            str = "士";
                            return str;
                        case Chess.Piecetype.jiang:
                            str = "将";
                            return str;
                        case Chess.Piecetype.pao:
                            str = "砲";
                            return str;
                        case Chess.Piecetype.bing:
                            str = "卒";
                            return str;
                    }

                    return str;
            }

            return str;
        }


        public Chess[,] SetPosition()   //设置棋子位置
        {
            Chess[,] Matrix = new Chess[19, 17];

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    Matrix[i, j] = new Chess();
                    Matrix[i, j].side = Chess.Player.blank;
                    Matrix[i, j].type = Chess.Piecetype.blank;
                }
            }

            for (int j = 0; j < 17; j++)
            {
                if (j % 2 == 0)
                {
                    Matrix[0, j].side = Chess.Player.black;
                    Matrix[18, j].side = Chess.Player.red;
                }

                if (j == 2 || j == 14)
                {
                    Matrix[4, j].side = Chess.Player.black;
                    Matrix[14, j].side = Chess.Player.red;
                }
                else if (j % 4 == 0)
                {
                    Matrix[6, j].side = Chess.Player.black;
                    Matrix[12, j].side = Chess.Player.red;
                }
            }

            for (int i = 0; i < 19; i++)
            {
                if (i == 0 || i == 18)
                {
                    Matrix[i, 0].type = Chess.Piecetype.che;
                    Matrix[i, 2].type = Chess.Piecetype.ma;
                    Matrix[i, 4].type = Chess.Piecetype.xiang;
                    Matrix[i, 6].type = Chess.Piecetype.shi;
                    Matrix[i, 8].type = Chess.Piecetype.jiang;
                    Matrix[i, 10].type = Chess.Piecetype.shi;
                    Matrix[i, 12].type = Chess.Piecetype.xiang;
                    Matrix[i, 14].type = Chess.Piecetype.ma;
                    Matrix[i, 16].type = Chess.Piecetype.che;
                }
                else if (i == 4 || i == 14)
                {
                    Matrix[i, 2].type = Chess.Piecetype.pao;
                    Matrix[i, 14].type = Chess.Piecetype.pao;
                }
                else if (i == 6 || i == 12)
                {
                    for (int j = 0; j < 17; j++)
                    {
                        if (j % 4 == 0)
                        {
                            Matrix[i, j].type = Chess.Piecetype.bing;
                        }
                    }
                }
            }

            return Matrix;
        }


        public string[,] Piece(Chess[,] Matrix)          //把棋子一个个弄到棋盘上
        {
            string[,] result = Board.DrawingBoard();
            string str;

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    str = result[i, j];
                    result[i, j] = Word(Matrix, str, i, j);
                }
            }

            return result;
        }


        public Chess[,] SetRoad()          //初始化并设置棋子路径
        {
            Chess[,] road = new Chess[19, 17];

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    road[i, j] = new Chess();
                    road[i, j].path = Chess.Piecepath.not;
                }
            }

            return road;
        }
    }
}   