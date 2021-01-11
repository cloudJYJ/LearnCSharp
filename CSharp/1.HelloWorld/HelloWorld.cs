using System;
using System.Collections.Generic;
using static System.Console;

namespace BrainCSharp
{
    class HelloWorld
    {
        // 프로그램 실행이 시작되는 곳
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                WriteLine("사용법 : HelloWorld.exe <이름>");
                return;
            }else if(args[0] == "연습문제")
            {
                WriteLine("여러분, 안녕하세요?");
                WriteLine("반갑습니다!");
                return;
            }
            WriteLine("Hello, {0}!",args[0]); // Hellow, World를 프롬프트에 출력
        }
    }
}
