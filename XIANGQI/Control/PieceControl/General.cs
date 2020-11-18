using System;
using Model;

namespace Control
{
    class General
    {
        public bool Jiang(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            ProCon con = new ProCon();
            int i, j, k;

            if (chozenX == X)
            {
                i = chozenY < Y ? chozenY : Y;
                j = chozenY > Y ? chozenY : Y;

                for (k = i + 1; k < j; k++)
                {
                    if (Matrix[X, k].side != Chess.Player.blank)
                    {
                        return false;
                    }
                }
            }

            if (Matrix[X, Y].type == Chess.Piecetype.jiang && chozenY == Y)
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

                if (Matrix[chozenX, chozenY].side == Matrix[X, Y].side)
                {
                    return false;
                }

                con.SetMove(X, Y, chozenX, chozenY, Matrix);

                return true;
            }

            if (Matrix[chozenX, chozenY].side == Chess.Player.black)
            {
                if (Y < 6 || Y > 10 || X > 4)
                {
                    return false;
                }
            }
            else
            {
                if (Y < 6 || Y > 10 || X < 14)
                {
                    return false;
                }
            }

            if ((Math.Abs(chozenX / 2 - X / 2) == 0 && Math.Abs(chozenY - Y) != 2) || (Math.Abs(chozenX / 2 - X / 2) == 1 && Math.Abs(chozenY - Y) != 0) || (Math.Abs(chozenX / 2 - X / 2) > 1))
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