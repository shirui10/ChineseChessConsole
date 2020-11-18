using System;
using Model;

namespace Control
{
    class Soldier: ProCon
    {
        public bool Bing(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {

            if (X != chozenX && Y != chozenY)
            {
                return false;
            }

            if (Matrix[chozenX, chozenY].side == Chess.Player.black)
            {
                if (chozenX < 10 && X - chozenX != 2)
                {
                    return false;
                }

                if (chozenX > 8)
                {
                    if (X == chozenX && Math.Abs(Y - chozenY) != 2)
                    {
                        return false;
                    }

                    if (Y == chozenY && X - chozenX != 2)
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (chozenX > 8 && chozenX - X != 2)
                {
                    return false;
                }

                if (chozenX < 10)
                {
                    if (X == chozenX && Math.Abs(Y - chozenY) != 2)
                    {
                        return false;
                    }

                    if (Y == chozenY && chozenX - X != 2)
                    {
                        return false;
                    }
                }
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