using System;
using Model;

namespace Control
{
    class General: ProCon
    {
        public bool Jiang(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            int i, j, k;

            if (Matrix[X, Y].type == Chess.Piecetype.jiang && chozenY == Y)         //飞将
            {
                i = chozenX < X ? chozenX : X;
                j = chozenX > X ? chozenX : X;

                for (k = i + 1; k < j; k++)                             //遍历当前列，当双方将军直接有其他棋子时不能飞将
                {
                    if (Matrix[k, Y].side != Chess.Player.blank)
                    {
                        return false;
                    }
                }

                if (Matrix[chozenX, chozenY].side == Matrix[X, Y].side)         //避免走到自己方的棋子上（其实这在飞将时有点多余）
                {
                    return false;
                }

                SetMove(X, Y, chozenX, chozenY, Matrix);

                return true;        //先一个setmove，为了能飞将时能移动，避免被下面的条件限制
            }

            if (Matrix[chozenX, chozenY].side == Chess.Player.black)        //限制黑方将军在九宫格内移动
            {
                if (Y < 6 || Y > 10 || X > 4)
                {
                    return false;
                }
            }
            else
            {                                                       //限制红方将军在九宫格内移动
                if (Y < 6 || Y > 10 || X < 14)
                {
                    return false;
                }
            }

            if ((Math.Abs(chozenX / 2 - X / 2) == 0 && Math.Abs(chozenY - Y) != 2) || (Math.Abs(chozenX / 2 - X / 2) == 1 && Math.Abs(chozenY - Y) != 0)|| (Math.Abs(chozenX / 2 - X / 2) > 1))
            {
                return false;                           //水平移动时，移动距离仅为1格 ｜｜ 竖直移动时，移动距离为1格 ｜｜ 避免第一次移动将时可移动距离大于一个格
            }

            if (Matrix[chozenX, chozenY].side == Matrix[X, Y].side)             //避免走到自己方的棋子上
            {
                return false;
            }

            SetMove(X, Y, chozenX, chozenY, Matrix);

            return true;
        }
    }
}