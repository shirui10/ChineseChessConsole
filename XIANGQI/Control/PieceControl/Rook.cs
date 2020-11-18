using System;
using Model;

namespace Control
{
    class Rook: ProCon
    {
        public bool Che(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            int i, j, k;

            if (chozenX == X)
            {
                i = chozenY < Y ? chozenY : Y;//如果chozenY<Y为ture 返回chozenY 否则Y；
                j = chozenY > Y ? chozenY : Y;

                for (k = i + 1; k < j; k++)
                {
                    if (Matrix[X, k].side != Chess.Player.blank)
                    {
                        return false;
                    }
                }
            }

            if (chozenY == Y)
            {
                i = chozenX < X ? chozenX : X;
                j = chozenX > X ? chozenX : X;

                for (k = i + 1; k < j; k++)
                {
                    if (Matrix[k, Y].side != Chess.Player.blank)
                    {
                        return false;
                    }
                }
            }

            if (chozenX != X && chozenY != Y)
            {
                return false;
            }

            if (Matrix[chozenX, chozenY].side == Matrix[X, Y].side)
            {
                return false;
            }

            SetMove(X, Y, chozenX, chozenY, Matrix);

            return true;
        }
    }
}