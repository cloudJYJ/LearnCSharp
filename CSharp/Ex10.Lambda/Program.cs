using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10.Lambda
{
    class Program
    {
        // 익명 메소드를 람다식으로 수정하세요.
        static void Main(string[] args)
        {
            int[] array = { 11, 22, 33, 44, 55 };

            foreach(int a in array)
            {
                Func<int,int> action = (x) => x * x;
                Console.WriteLine($"{action(a)}");
            }
            Console.WriteLine("이 창을 닫으시려면 아무 키나 누르세요...");
            Console.ReadKey();
        }
    }
}
