using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex8.AnonymousMethod
{
    class Program
    {
        // 익명 메소드를 추가하여 코드를 완성 하세요.
        delegate int Mydelegate(int a, int b);
        static void Main()
        {
            Mydelegate Callback;
            Callback = delegate (int a, int b)
            {
                return a + b;
            };
            Console.WriteLine(Callback(3, 4));

            Callback = delegate (int a, int b)
            {
                return a - b;
            };
            Console.WriteLine(Callback(7, 5));
            Console.WriteLine("이 창을 닫으시려면 아무 키나 누르세요...");
            Console.ReadKey();
        }
    }
}
