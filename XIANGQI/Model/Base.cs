using System;

namespace Model
{
    public class Chess
    {                           //枚举
        public enum Player    //分为红黑两方
        {
            red,
            black,
            blank        //中间方
        };


        public enum Piecetype    //分为不同的棋子类型
        {
            blank,        //中间方的，即棋子以外的空格，方便棋子去移动
            jiang,
            che,
            ma,
            pao,
            xiang,
            bing,
            shi
        };


        public enum Piecepath     //能否行走
        {
            yes,
            not
        };


        public Player side;
        public Piecetype type;
        public Piecepath path;
    }
}
