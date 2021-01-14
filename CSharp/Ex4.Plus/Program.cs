using System;

namespace Ex4.Plus
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 4;
            int resultA = 0;

            Plus(a, b, out resultA);

            Console.WriteLine("{0} + {1} = {2}", a, b, resultA);

            double x = 2.4;
            double y = 3.1;
            double resultB = 0;

            Plus(x, y, out resultB);  // 오버로드가 필요한 메소드

            Console.WriteLine("{0} + {1} = {2}", x, y, resultB);
        }
        public static void Plus(int a,int b,out int c)
        {
            c = a + b;
        }
        // 이 아래에 double형 매개 변수를 받을 수 있도록
        // 오버로딩된 Plus() 메소드를 작성하세요.
        public static void Plus(double x, double y, out double z)
        {
            z = x + y;
        }
    }
}
