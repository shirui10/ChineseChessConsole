using System;
using Model;

namespace Control
{
    class Horse
    {
        public bool Ma(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {
            ProCon con = new ProCon();

            if (Math.Abs(chozenX / 2 - X / 2) == 1 && Math.Abs(chozenY - Y) == 4)
            {
                if (Matrix[chozenX, chozenY + 2 * (Y - chozenY) / Math.Abs(Y - chozenY)].side != Chess.Player.blank)
                {
                    return false;
                }
            }
            else if (Math.Abs(chozenX / 2 - X / 2) == 2 && Math.Abs(chozenY - Y) == 2)
            {
                if (Matrix[chozenX + (X - chozenX) / Math.Abs(X - chozenX) * 2, chozenY].side != Chess.Player.blank)
                {
                    return false;
                }
            }
            else
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