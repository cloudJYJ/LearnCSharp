using System;

    // 입력 받은 수를 제곱하여 반환하는 메소드를 구현하시오.
namespace Ex2.Square
{
    class Program
    {
        static double Square(double arg)
        {
            return arg * arg;
        }
        static void Main()
        {
            Console.Write("수를 입력하세요 : ");
            double arg = double.Parse(Console.ReadLine());

            Console.WriteLine("결과 : {0}", Square(arg));
        }
    }
}
