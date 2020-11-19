using System;
using Model;

namespace Control
{
    class Elephant: ProCon
    {
        public bool Xiang(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)
        {

            if (Matrix[chozenX, chozenY].side == Chess.Player.black)            //使象不能过河
            {
                if (X > 8)                                      //8和10为河界的行坐标
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

            if (Math.Abs((X - chozenX) / 2 ) * Math.Abs(Y - chozenY) != 8)      //选择的行坐标与移动前的行坐标的差的1/2的绝对值乘选择的列坐标和移动前的列坐标，其积不等于8时，粗略画出田字的路径。筛选条件1
            {
                return false;
            }

            if (Matrix[(X + chozenX) / 2, (Y + chozenY) / 2].side != Chess.Player.blank)        //使象走田字时，当要走的田中心有棋子时不能移动    
            {
                return false;
            }

            if (Math.Abs(X-chozenX) != 4 && Math.Abs(Y-chozenY) != 4)               //使象能行走的水平距离和竖直距离分别等于4（即隔一格）时才能行走，筛选条件2，进一步筛选1条件后可画出准确的田字路径
            {
                return false;
            }

            if (Matrix[chozenX, chozenY].side == Matrix[X, Y].side)                 //避免走到自己方的棋子上
            {
                return false;
            }

            SetMove(X, Y, chozenX, chozenY, Matrix);

            return true;
        }
    }
}