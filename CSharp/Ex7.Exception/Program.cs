using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex7.Exception
{
    class Program
    {
        // try~catch 문을 이용해서 예외를 안전하게 잡아 처리하도록 코드를 수정하세요.
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            try
            {
                for (int i = 0; i < 10; i++)
                    arr[i] = i;

                for (int i = 0; i < 11; i++)
                    while (arr[i]) ;
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
