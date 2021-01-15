using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6
{
    class Program
    {
        static void Main()
        {           
            // ↓ 익명 타입을 이용해서 완성하세요.
            // var nameCard =
            var nameCard = new { Name = "박상현", Age = 17 };
            Console.WriteLine("이름 : {0}, 나이 : {1}", nameCard.Name, nameCard.Age);

            // ↓ 익명 타입을 이용해서 완성하세요.
            // var complex = 
            var complex = new { Real = 3, Imaginary = -12 };
            Console.WriteLine("Real : {0}, Imaginary : {1}", complex.Real, complex.Imaginary);

            Console.WriteLine("이 창을 닫으려면 아무 키나 누르세요...");
            Console.ReadKey();
        }
    }
}
