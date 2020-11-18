using System;
using Model;

namespace Control
{
    class Cannon
    {
        public bool Pao(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            ProCon con = new ProCon();
            int i, j, k, n;

            if (chozenX == X)
            {
                i = chozenY < Y ? chozenY : Y;
                j = chozenY > Y ? chozenY : Y;
                n = 0;

                for (k = i + 1; k < j; k++)
                {
                    if (Matrix[X, k].side != Chess.Player.blank)
                    {
                        n++;
                    }
                }

                if (n > 1)
                {
                    return false;
                }
            }
            else if (chozenY == Y)
            {
                i = chozenX < X ? chozenX : X;
                j = chozenX > X ? chozenX : X;
                n = 0;

                for (k = i + 1; k < j; k++)
                {
                    if (Matrix[k, Y].side != Chess.Player.blank)
                    {
                        n++;
                    }
                }

                if (n > 1)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (n == 0 && Matrix[X, Y].side != Chess.Player.blank)
            {
                return false;
            }

            if (n == 1 && Matrix[X, Y].side == Chess.Player.blank)
            {
                return false;
            }

            if (Matrix[chozenX, chozenY].side == Matrix[X, Y].side)
            {
                return false;
            }

            con.SetMove(X, Y, chozenX, chozenY, Matrix);

            return true;
        }
    }
}
