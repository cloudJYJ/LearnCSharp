using System;

/* 문제
   다음과 같이 사용자로부터 사각형의 너비와 높이를 입력받아 넓이를 
   계산하는 프로그램을 완성하세요. 다음 코드 중 주석 부분을 바꾸면 됩니다.

   문제 코드
namespace RectArea
{
    class MainApp
    {
        public static void Main()
        {
            Console.WriteLine("사각형의 너비를 입력하세요.");
            string width = Console.ReadLine();

            Console.WriteLine("사각형의 높이를 입력하세요.");
            string height = Console.ReadLine();

            // 이 곳에 사각형의 넓이를 계산하고
            // 출력하는 루틴을 추가하세요.
        }
    }
}
*/
namespace Ex1.RectArea
{
    class MainApp
    {
        public static void Main()
        {
            Console.WriteLine("사각형의 너비를 입력하세요.");
            string width = Console.ReadLine();

            Console.WriteLine("사각형의 높이를 입력하세요.");
            string height = Console.ReadLine();

            Console.WriteLine("사각형의 넓이 : {0} ", int.Parse(width)*int.Parse(height));
        }
    }
}