using System;
using Model;

namespace Control
{
    class Horse: ProCon
    {
        public bool Ma(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {

            if (Math.Abs(chozenX / 2 - X / 2) == 1 && Math.Abs(chozenY - Y) == 4)           //横着走日字
            {
                if (Matrix[chozenX, chozenY + 2 * (Y - chozenY) / Math.Abs(Y - chozenY)].side != Chess.Player.blank)        //避免斩马腿
                {
                    return false;
                }
            }
            else if (Math.Abs(chozenX / 2 - X / 2) == 2 && Math.Abs(chozenY - Y) == 2)      //竖着走日字
            {
                if (Matrix[chozenX + (X - chozenX) / Math.Abs(X - chozenX) * 2, chozenY].side != Chess.Player.blank)        //避免斩马腿
                {
                    return false;
                }
            }
            else
            {                                                       //避免走出日字以外的路径
                return false;
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