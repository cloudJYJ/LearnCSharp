using System;
using static System.Console;

namespace _5.FlowControl
{
    class FlowControl
    {
        static void Main()
        {
            WriteLine("[ 1 ] 분기문");
            WriteLine("[ 2 ] 중첩 분기문");
            WriteLine("[ 3 ] 스위치문");
            WriteLine("[ 4 ] 정수,문자열 외의 스위치문");
            WriteLine("[ 5 ] While 반복문");
            WriteLine("[ 6 ] DoWhile 반복문");
            WriteLine("[ 7 ] For 반복문");
            WriteLine("[ 8 ] 중첩 For문");
            WriteLine("[ 9 ] Foreach 반복문");
            WriteLine("[10 ] 무한 반복문, break문");
            WriteLine("[11 ] Continue문");
            WriteLine("[12 ] Goto문");
            string choice = ReadLine();
            if (choice == "1") { IfElse ifelse = new IfElse(); }
            if (choice == "2") { IfIf ifif = new IfIf(); }  
            if (choice == "3") { Switch Switch = new Switch(); }
            if (choice == "4") { Switch2 Switch2 = new Switch2(); }
            if (choice == "5") { While While = new While(); }
            if (choice == "6") { DoWhile DoWhile = new DoWhile(); }
            if (choice == "7") { For For = new For(); }
            if (choice == "8") { ForFor ForFor = new ForFor(); }
            if (choice == "9") { Foreach Foreach = new Foreach(); }
            if (choice == "10") { Infinite Infinite = new Infinite(); }
            if (choice == "11") { Continue Continue = new Continue(); }
            if (choice == "12") { Goto Goto = new Goto(); }

        }
    }
    class IfElse
    {
        public IfElse()
        {
            Write("숫자를 입력하세요. : ");

            int number = int.Parse(ReadLine());

            if (number < 0)
                WriteLine("음수");
            else if (number > 0)
                WriteLine("양수");
            else
                WriteLine("0");

            if (number % 2 == 0)
                WriteLine("짝수");
            else
                WriteLine("홀수");
        }
    }                 // 1. 분기문
    class IfIf
    {
        public IfIf()
        {
            Write("숫자를 입력하세요. : ");

            int number = int.Parse(ReadLine());

            if(number > 0)
            {
                if (number % 2 == 0)
                    WriteLine("0보다 큰 짝수.");
                else
                    WriteLine("0보다 큰 홀수.");
            }
            else
            {
                WriteLine("0보다 작거나 같은 수");
            }
        }
    }                   // 2. 중첩 분기문
    class Switch
    {
        public Switch()
        {
            Write("요일을 입력하세요(일, 월, 화, 수, 목, 금, 토) : ");
            string day = ReadLine();

            switch (day)
            {
                case "일":
                    WriteLine("Sunday");
                    break;
                case "월":
                    WriteLine("Monday");
                    break;
                case "화":
                    WriteLine("Tuesday");
                    break;
                case "수":
                    WriteLine("Wednesday");
                    break;
                case "목":
                    WriteLine("Thursday");
                    break;
                case "금":
                    WriteLine("Friday");
                    break;
                case "토":
                    WriteLine("Saturday");
                    break;
                default:
                    WriteLine($"{day}는(은) 요일이 아닙니다.");
                    break;
            }
        }
    }                 // 3. 스위치문
    class Switch2
    {
        public Switch2()
        {
            object obj = null;

            string s = ReadLine();
            if (int.TryParse(s, out int out_i))
                obj = out_i;
            else if (float.TryParse(s, out float out_f))
                obj = out_f;
            else
                obj = s;

            switch (obj)
            {
                case int i:
                    WriteLine($"{i}는 int 형식입니다.");
                    break;
                case float f:
                    WriteLine($"{f}는 float 형식입니다.");
                    break;
                default:
                    WriteLine("{obj}는 모르는 형식입니다.");
                    break;
            }
        }
    }                // 4. 정수,문자열 외의 스위치문
    class While
    {
        public While()
        {
            int i = 10;
            while( i > 0 )
            {
                WriteLine($"i : {i--}");
            }
        }
    }                  // 5. While반복문
    class DoWhile
    {
        public DoWhile()
        {
            int i = 10;
            do
            {
                WriteLine("a) i : {0}", i--);
            }
            while (i > 0);

            do
            {
                WriteLine("b) i : {0}", i--);
            }
            while (i > 0);
        }
    }                // 6. DoWhile반복문
    class For
    {
        public For()
        {
            for(int i = 0; i < 5; i++)
            {
                WriteLine(i);
            }
        }
    }                    // 7. For반복문
    class ForFor
    {
        public ForFor()
        {
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    Write("*");
                }
                WriteLine();
            }
        }
    }                 // 8. 중첩For문
    class Foreach
    {
        public Foreach()
        {
            int[] arr = new int[] { 0, 1, 2, 3, 4 };

            foreach(int a in arr)
            {
                WriteLine(a);
            }
        }
    }                // 9. Foreach 반복문
    class Infinite
    {
        public Infinite()
        {
            int i = 0;
            WriteLine("무한 반복 For문");
            for (; ; )
            {
                WriteLine("반복횟수 : {0}", i++);
                Write("종료 Y/N :");
                string Exit = ReadLine();
                if (Exit == "Y")
                    break;
            }
            i = 0;
            WriteLine("무한 반복 while문");
            while (true)
            {
                WriteLine("반복횟수 : {0}", i++);
                Write("종료 Y/N :");
                string Exit = ReadLine();
                if (Exit == "Y")
                    break;
            }
        }
    }               // 10. 무한 반복문,break
    class Continue
    {
        public Continue()
        {
            for( int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    continue;

                WriteLine($"{i} : 홀수");
            }
        }
    }               // 11. Continue문
    class Goto
    {
        public Goto()
        {
            Write("종료 조건(숫자)를 입력하세요 : ");

            string input = ReadLine();

            int input_number = Convert.ToInt32(input);

            int exit_number = 0;
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    for(int k = 0; k < 3; k++)
                    {
                        if (exit_number++ == input_number)
                            goto EXIT_FOR;

                        WriteLine(exit_number);
                    }
                }
            }

            goto EXIT_PROGRAM;

        EXIT_FOR:
            WriteLine("\nExit nested for...");

        EXIT_PROGRAM:
            WriteLine("Exit program");
        }
    }                   // 12. Goto문
}
