using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShape
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 20;
            int hight = 20;
            for (int y = 0; y < hight; y++)
            {
                for (int x =0; x < width; x++)
                {
                    Console.Write(f((x+y/3*3)%6-2,y%3) ? " * " : "   ");
                }

                Console.Write("\n");
            }

            Console.Read();

        }

       
        static bool f(int x, int y)
        {
            //圆
            //return x * x + y * y <= 25;
            //等腰直角三角形
            return  Math.Abs( x) <= y;
        }
    }
}
