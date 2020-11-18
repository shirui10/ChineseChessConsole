using System;
using Model;

namespace Control
{
    class Elephant: ProCon
    {
        public bool Xiang(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {

            if (Matrix[chozenX, chozenY].side == Chess.Player.black)
            {
                if (X > 8)
                {
                    return false;
                }
            }
            else
            {
                if (X < 10)
                {
                    return false;
                }
            }

            if (Math.Abs((X - chozenX) / 2 ) * Math.Abs(chozenY - Y) != 8)
            {
                return false;
            }

            if (Matrix[(X + chozenX) / 2, (Y + chozenY) / 2].side != Chess.Player.blank)
            {
                return false;
            }

            if (Math.Abs(X-chozenX) != 4 && Math.Abs(Y-chozenY) != 4)
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