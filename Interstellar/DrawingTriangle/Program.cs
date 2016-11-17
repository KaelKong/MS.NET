using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DrawingTriangle
{
    class Program
    {
        static string result = string.Empty;
        static bool flag = false;
        private static object obj = new object();
        static void Main(string[] args)
        {
            for (float a = 0; a < 10; a++)
            {
                Console.WriteLine(a);
                Thread t2 = new Thread(new ParameterizedThreadStart(SubProgram));
                t2.IsBackground = true;
                t2.Start(a);
            }

            Console.Read();
        }

        static void CalcResult()
        {
            for (float a = 0; a < 1000; a++)
            {
                if (flag) break;
                for (float b = 0; b < 1000; b += (float)0.5)
                {
                    if (flag) break;
                    for (float c = 0; c < 1000; c += (float)0.5)
                    {
                        if (flag) break;
                        for (float d = 0; d < 1000; d += (float)0.5)
                        {
                            float[] matrix = new float[] { a, b, c, d };
                            Thread t2 = new Thread(new ParameterizedThreadStart(Test));
                            t2.IsBackground = true;
                            t2.Start(matrix);
                        }
                    }
                }
            }


            Console.Read();
        }

        static void SubProgram(object obj)
        {
            float start = (float)obj;
            float a = start;
            for (; a < start+1; a+=(float)0.1)
            {
                Console.WriteLine(a);
                if (flag) break;

                for (float b = 0; b < 10; b += (float)0.10)
                {
                  
                    if (flag) break;
                    for (float c = 0; c < 10; c += (float)0.10)
                    {
                        if (flag) break;
                        for (float d = 0; d < 10; d += (float)0.1)
                        {
                            if (flag) break;
                            if (a + b == 8 && a + c == 13 && b + d == 8 && c - d == 6)
                            {
                                lock (obj)
                                {
                                    flag = true;
                                }
                                Console.WriteLine("The answer is {0},{1},{2},{3}", a, b, c, d);
                                Console.WriteLine("The answer is {0},{1},{2},{3}", a, b, c, d);
                                Console.WriteLine("The answer is {0},{1},{2},{3}", a, b, c, d);
                                Console.WriteLine("The answer is {0},{1},{2},{3}", a, b, c, d);
                            }
                        }
                    }
                }
            }
        }



        static void Test(object obj)
        {
            float[] matrix = (float[])obj;
            Console.WriteLine("当前位置：a:{0},b:{1},c:{2},d:{3}", matrix[0], matrix[1], matrix[2], matrix[3]);
            if (matrix[0] + matrix[1] == 8 && matrix[0] + matrix[2] == 13 && matrix[1] + matrix[3] == 8 && matrix[2] - matrix[3] == 6)
            {
                Console.WriteLine("计算结果：a:{0},b:{1},c:{2},d:{3}", matrix[0], matrix[1], matrix[2], matrix[3]);
                lock (obj)
                {
                    flag = true;
                }
            }
        }
        //画三角形
        static void DrawTriangle()
        {
            /*输入参数*/
            /*
                            *
                          ***
                        ***** ----------------------------------------第一行
                       *        *
                     ***     ***
                   *****  *****-------------------------------------第二行
             */
            int row = 10;  //需要生成的行数（以一个完整三角形为一行）

            /*
                            *
                          ***
                        ***** ----------------------------------------三角形大小为 3 层
                           *         
                         ***     
                       *****
                     ******* ---------------------------------------三角形大小为 4 层   
             */
            int triangleRow = 1; //输入模型三角形大小

            /*图形参数*/

            int[] pointNumber = new int[triangleRow];
            pointNumber[0] = 1;

            for (int i = 1; i < triangleRow; i++)
            {
                pointNumber[i] = pointNumber[i - 1] + 2;
            }

            int width = pointNumber[triangleRow - 1];  //三角形的长
            int hight = triangleRow;  //三角形的高
            int distance = width + 1;  //每两个三角形间的距离
            int x = width * row + row - 1;  //计算出整个图形的宽
            int y = hight * row;                 //计算出整个图形的高


            /*绘制*/
            for (int i = 0; i < y; i++)
            {
                int start = x / 2 - i;
                int pointLevel = pointNumber[i % hight];                           //计算出当前行是在模型三角形中的哪一行
                int totalCount = pointNumber[i % hight] * (i / hight + 1);  //计算当前行应该有多少个点

                int currentCount = 0;  //记录已绘制多少个点
                int cusor = start;         //设置需要绘制点的横向坐标
                for (int j = 0; j < x; j++)
                {
                    if (j == cusor && currentCount < totalCount) //判断出该点是否需要绘制
                    {
                        Console.Write(" * ");
                        currentCount += 1; //绘制后记录已绘制点数
                        if (currentCount % pointLevel == 0)  //判断是否在模型三角形的尾部
                        {
                            cusor = start += distance;  //在尾部直接调到下一个三角位置
                        }
                        else
                        {
                            cusor += 1;
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    //System.Threading.Thread.Sleep(10);
                }


                Console.Write("\n");
            }

            Console.Read();
        }
    }
}
