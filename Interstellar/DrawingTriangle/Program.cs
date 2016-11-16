using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingTriangle
{
    class Program
    {
        static void Main(string[] args)
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

            int width = pointNumber[triangleRow-1];  //三角形的长
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
