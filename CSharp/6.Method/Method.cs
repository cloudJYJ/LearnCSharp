using System;
using static System.Console;

namespace _6.Method
{
    class Method
    {
        static void Main()
        {
            WriteLine("[ 1 ] 간단한 계산기 메소드");
            WriteLine("[ 2 ] Return문");
            WriteLine("[ 3 ] 매개변수");
            WriteLine("[ 4 ] 참조에 의한 전달");
            WriteLine("[ 5 ] 참조 반환");
            WriteLine("[ 6 ] 출력 전용 매개변수");
            WriteLine("[ 7 ] 오버로딩");
            WriteLine("[ 8 ] 가변 길이 매개변수");
            WriteLine("[ 9 ] 명명된 매개변수");
            WriteLine("[10 ] 선택적 매개변수");
            WriteLine("[11 ] 지역 함수");
            string choice = ReadLine();
            if (choice == "1") { Calculator Calculator = new Calculator(); }
            if (choice == "2") { Return Return = new Return(); }
            if (choice == "3") { SwapByValue SwapByValue = new SwapByValue(); }
            if (choice == "4") { SwapByRef SwapByRef = new SwapByRef(); }
            if (choice == "5") { RefReturn RefReturn = new RefReturn(); }
            if (choice == "6") { UsingOut UsingOut = new UsingOut(); }
            if (choice == "7") { Overloading Overloading = new Overloading(); }
            if (choice == "8") { UsingParams UsingParamas = new UsingParams(); }
            if (choice == "9") { NamedParameter NamedParameter = new NamedParameter(); }
            if (choice == "10") { OptionalParameter OptionalParameter = new OptionalParameter(); }
            if (choice == "11") { LocalFunction localFunction = new LocalFunction(); }
        }
    }
    class Calculator
    {
        public Calculator()
        {
            WriteLine(Calculator.Plus(3, 4));
            WriteLine(Calculator.Minus(5, 2));
        }
        public static int Plus(int a,int b)
        {
            return a + b;
        }
        public static int Minus(int a, int b)
        {
            return a - b;
        }
    }               // 1. 간단한 계산기 메소드
    class Return
    {
        public Return()
        {
            WriteLine($"10번째 피보나치 수 : {Fibonacci(10)}");

            PrintProfile("", "123-4567");
            PrintProfile("정용준", "456-1230");
        }
        static int Fibonacci(int n)
        {
            if (n < 2)
                return n;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        static void PrintProfile(string name, string phone)
        {
            if(name == "")
            {
                WriteLine("이름을 입력해주세요.");
                return;
            }
            WriteLine($"Name:{name}, Phone:{phone}");
        }
    }                   // 2. Return문
    class SwapByValue
    {
        public SwapByValue()
        {
            int x = 3;
            int y = 4;

            WriteLine($"x:{x}, y:{y}");

            Swap(x, y);

            WriteLine($"x:{x}, y:{y}");
        }
        public static void Swap(int a, int b)
        {
            int temp = b;
            b = a;
            a = temp;
            WriteLine($"메소드내에서 바뀐 값 x:{a}, y:{b}");
        }
    }              // 3. 매개변수
    class SwapByRef
    {
        public SwapByRef()
        {
            int x = 3;
            int y = 4;
            WriteLine($"x:{x}, y:{y}");

            Swap(ref x, ref y);                          // 참조에 의한 전달로써 매개 변수가 메소드에 넘겨진 원본 변수를 직접 참조함.
                                                         // 메소드 안에서 매개변수를 수정하면 이 매개 변수가참조하고 있는 원본 변수에 수정이 이루어짐.
            WriteLine($"x:{x}, y:{y}");
        }
        static void Swap(ref int a,ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
            WriteLine($"메소드내에서 바뀐 값 x:{a}, y:{b}");
        }
    }                // 4. 참조에 의한 전달
    class RefReturn
    {
        public RefReturn()
        {
            Product carrot = new Product();
            ref int ref_local_price = ref carrot.GetPrice();
            int normal_local_price = carrot.GetPrice();

            carrot.PrintPrice();
            WriteLine($"Ref Local Price :{ref_local_price}");
            WriteLine($"Normal Local Price :{normal_local_price}");

            ref_local_price = 200;

            carrot.PrintPrice();
            WriteLine($"Ref Local Price :{ref_local_price}");
            WriteLine($"Normal Local Price :{normal_local_price}");
        }
        class Product
        {
            private int price = 100;

            public ref int GetPrice()
            {
                return ref price;
            }

            public void PrintPrice()
            {
                WriteLine($"Price :{price}");
            }
        }
    }                // 5. 참조 반환
    class UsingOut
    {
        public UsingOut()
        {
            int a = 20;
            int b = 3;

            Devide(a, b, out int c, out int d);

            WriteLine($"a:{a}, b:{b}, a/b:{c}, a%b:{d}");
        }
        static void Devide(int a, int b,out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
        }
    }                 // 6. 출력 전용 매개변수
    class Overloading
    {
        public Overloading()
        {
            WriteLine(Plus(1,2));
            WriteLine(Plus(1,2,3));
            WriteLine(Plus(1.0,2.4));
            WriteLine(Plus(1,2.4));
        }

        static int Plus(int a, int b)
        {
            WriteLine("Calling int Plus(int,int)...");
            return a + b;
        }

        static int Plus(int a, int b, int c)
        {
            WriteLine("Calling int Plus(int,int,int)...");
            return a + b + c;
        }

        static double Plus(double a, double b)
        {
            WriteLine("Calling double Plus(double,double)...");
            return a + b;
        }

        static double Plus(int a, double b)
        {
            WriteLine("Calling double Plus(int,double)...");
            return a + b;
        }
    }              // 7. 오버로딩
    class UsingParams
    {
        static int Sum(params int[] args)
        {
            Write("Summing... ");

            int sum = 0;
            foreach(var i in args)
            {
                if (sum != 0)
                    Write(", ");
                Write(i);
                sum += i;
            }
            WriteLine();

            return sum;
        }
        public UsingParams()
        {
            int sum = Sum(3, 4, 5, 6, 7, 8, 9, 10);
            WriteLine($"Sum : {sum}");
        }
    }              // 8. 가변 길이 매개변수
    class NamedParameter
    {
        public NamedParameter()
        {
            PrintProfile(name: "박찬호", phone: "010-123-1234");
            PrintProfile(phone: "010-987-9876", name: "박지성");
            PrintProfile("박세리", "010-222-2222");
            PrintProfile("박상현", phone: "010-567-5678");
        }
        static void PrintProfile(string name, string phone)
        {
            WriteLine($"Name:{name}, Phone:{phone}");
        }
    }           // 9. 명명된 매개변수
    class OptionalParameter
    {
        public OptionalParameter()
        {
            PrintProfile("태연");
            PrintProfile("윤아", "010-123-1234");
            PrintProfile(name: "유리");
            PrintProfile(name: "서현", phone: "010-789-7890");
        }
        static void PrintProfile(string name, string phone = "")
        {
            WriteLine($"Name:{name}, Phone:{phone}");
        }
    }        // 10. 선택적 매개변수
    class LocalFunction
    {
        public LocalFunction()
        {
            WriteLine(ToLowerString("Hello"));
            WriteLine(ToLowerString("Good Morning"));
            WriteLine(ToLowerString("This is C#."));
        }

        static string ToLowerString(string input)
        {
            var arr = input.ToCharArray();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = ToLowerChar(i);
            }

            char ToLowerChar(int i)
            {
                if (arr[i] < 65 || arr[i] > 90) // A~Z의 ASCII 값 : 65 ~ 90
                    return arr[i];
                else // a~z의 ASCII 값 : 97 ~ 122
                    return (char)(arr[i] + 32);
            }

            return new string(arr);
        }
    }            // 11. 지역 함수
}
