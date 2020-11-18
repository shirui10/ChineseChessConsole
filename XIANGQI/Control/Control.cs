using System;
using Model;


namespace Control
{
    public class ProCon
    {
        static void Main(string[] args)
        {
        }


        public int turn = 0;        //回合数从0开始


        public bool SwitchPlayer(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)       //选棋子，让其在一方回合时不能选择对方棋子
        {
            if (turn == 0)
            {
                if (Matrix[chozenX, chozenY].side != Chess.Player.red)
                {
                    return false;
                }
                else
                {
                    bool check = MovePiece(X, Y, chozenX, chozenY, Matrix);
                    if (check == true)
                    {
                        turn = 1;
                        return true;
                    }
                    else return false;
                }
            }
            else if (turn == 1)
            {
                if (Matrix[chozenX, chozenY].side != Chess.Player.black)
                {
                    return false;
                }
                else
                {
                    bool check = MovePiece(X, Y, chozenX, chozenY, Matrix);
                    if (check == true)
                    {
                        turn = 0;
                        return true;
                    }
                    else return false;
                }
            }
            else return false;
        }


        public bool Result(Chess[,] Matrix)       //判断结果
        {
            int n = 0;
            bool result = true;

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    if (Matrix[i, j].type == Chess.Piecetype.jiang)
                    {
                        n++;
                    }
                }
            }

            if (n == 2)
            {
                return result;
            }
            else
            {
                result = false;
                return result;
            }
        }


        public bool MovePiece(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)       //定义每种棋子的移动方式
        {
            Rook che = new Rook();
            Horse ma = new Horse();
            Elephant xiang = new Elephant();
            Advisor shi = new Advisor();
            General jiang = new General();
            Cannon pao = new Cannon();
            Soldier bing = new Soldier();
            bool re;

            switch (Matrix[chozenX, chozenY].type)
            {
                case Chess.Piecetype.che:
                    re = che.Che(X, Y, chozenX, chozenY, Matrix);
                    return re;
                case Chess.Piecetype.ma:
                    re = ma.Ma(X, Y, chozenX, chozenY, Matrix);
                    return re;
                case Chess.Piecetype.xiang:
                    re = xiang.Xiang(X, Y, chozenX, chozenY, Matrix);
                    return re;
                case Chess.Piecetype.shi:
                    re = shi.Shi(X, Y, chozenX, chozenY, Matrix);
                    return re;
                case Chess.Piecetype.jiang:
                    re = jiang.Jiang(X, Y, chozenX, chozenY, Matrix);
                    return re;
                case Chess.Piecetype.pao:
                    re = pao.Pao(X, Y, chozenX, chozenY, Matrix);
                    return re;
                case Chess.Piecetype.bing:
                    re = bing.Bing(X, Y, chozenX, chozenY, Matrix);
                    return re;
            }

            return false;
        }


        public Chess[,] Road(int chozenX, int chozenY, Chess[,] Matrix)      // 使棋子显示可行路径时，并使移动前的棋子不移动
        {
            ProMod mod = new ProMod();                  //实例化，方便使用该类里的方法
            Chess[,] road = mod.SetRoad();              //用Chess类创建出一个[19，17]的road数组，并一个个实例，再初始化路径，即将Chess.Piecepath.not赋到每个road里
            Chess[,] trans = new Chess[19, 17];         //用Chess类创建出一个[19，17]的trans数组，方便临时储存信息
            bool cr;

            for (int i = 0; i < 19; i++)                //遍历整个棋盘
            {
                for (int j = 0; j < 17; j++)
                {
                    trans[i, j] = new Chess();             //通过循环，一个个地具体实例化每个trans
                }
            }

            for (int i = 0; i < 19; i++)                //遍历整个棋盘
            {
                for (int j = 0; j < 17; j++)
                {
                    if (i % 2 == 0)                     //因为x实际的坐标是输入坐标的两倍，即都为偶数的x才是棋盘上的的点
                    {
                        trans[i, j].side = Matrix[i, j].side;           //把每个位置的side属性一个个赋到trans上暂时储存
                        trans[i, j].type = Matrix[i, j].type;              //把每个位置的type属性一个个赋到trans上暂时储存
                        trans[chozenX, chozenY].side = Matrix[chozenX, chozenY].side;      //把当前选择的具体位置的side属性赋到trans暂时储存
                        trans[chozenX, chozenY].type = Matrix[chozenX, chozenY].type;       //把当前选择的具体位置的type属性赋到trans暂时储存
                        cr = MovePiece(i, j, chozenX, chozenY, Matrix);                 //使用该方法依据棋子类型，通过遍历一个个检查当前选择的棋子能走的格子，通过返回true或false来形成路径

                        if (cr == true)     //如果该格子能走
                        {
                            road[i, j].path = Chess.Piecepath.yes;      //把该格子的位置的path属性里赋上Chess.Piecepath.yes,即把之前初始化的not变成了yes
                        }

                        Matrix[i, j].side = trans[i, j].side;           //每遍历了一个位置后及时把该位置的属性再赋回去，避免选择该棋子准备进行移动时棋子就已经提前移动影响整个函数的判断
                        Matrix[i, j].type = trans[i, j].type;
                        Matrix[chozenX, chozenY].side = trans[chozenX, chozenY].side;
                        Matrix[chozenX, chozenY].type = trans[chozenX, chozenY].type;
                    }
                }
            }

            return road;            //返回road即可行路径
        }


        public int CheckPiece(int chozenX, int chozenY, Chess[,] Matrix)                //检测选中的是否棋子
        {
            if (Matrix[chozenX, chozenY].type == Chess.Piecetype.blank)
            {
                return 0;
            }
            else if (turn == 0)
            {
                if (Matrix[chozenX, chozenY].side != Chess.Player.red)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else if (turn == 1)
            {
                if (Matrix[chozenX, chozenY].side != Chess.Player.black)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            return 0;
        }


        public void SetMove(int X, int Y, int chozenX, int chozenY, Chess[,] Matrix)       //基本移动方式
        {
            Matrix[X, Y].side = Matrix[chozenX, chozenY].side;
            Matrix[X, Y].type = Matrix[chozenX, chozenY].type;
            Matrix[chozenX, chozenY].side = Chess.Player.blank;
            Matrix[chozenX, chozenY].type = Chess.Piecetype.blank;
        }
    }
}