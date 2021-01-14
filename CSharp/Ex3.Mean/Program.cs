using System;
    // 다음 코드에서 Mean() 메소드를 실행한 값이 0을 갖게되는 원인과 정상적으로 작동하도록 고치시오.
namespace Ex3.Mean
{
    class Program
    {
        static void Main()
        {
            double mean = 0;
            //Mean(1, 2, 3, 4, 5, mean);
            Mean(1, 2, 3, 4, 5, ref mean);
            Console.WriteLine("평균 : {0}", mean);
        }

        public static void Mean(
                double a, double b, double c,
                double d, double e, ref double mean// double mean
            )
        {
             mean = (a + b + c + d + e)/5;
        }
    }
}
