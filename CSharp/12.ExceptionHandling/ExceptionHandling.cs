using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _12.ExceptionHandling
{
    class ExceptionHandling
    {
        static void Main()
        {
            WriteLine("[ 1 ] 예외 상황");
            WriteLine("[ 2 ] TryCatch문");
            WriteLine("[ 3 ] Throw문");
            WriteLine("[ 4 ] 예외 던지기");
            WriteLine("[ 5 ] Finally문");
            WriteLine("[ 6 ] 사용자 정의 예외");
            WriteLine("[ 7 ] 예외 필터");
            WriteLine("[ 8 ] StackTrace");
            string choice = ReadLine();
            if(choice == "1") { Exception exception = new Exception(); }
            if(choice == "2") { TryCatch trycatch = new TryCatch(); }
            if(choice == "3") { Throw Throw = new Throw(); }
            if(choice == "4") { ThrowException throwexception = new ThrowException(); }
            if(choice == "5") { Finally FInally = new Finally(); }
            if(choice == "6") { MyException myexception = new MyException(); }
            if(choice == "7") { ExceptionFiltering exceptionfiltering = new ExceptionFiltering(); }
            if(choice == "8") { StackTrace stacktrace = new StackTrace(); }
            WriteLine("이 창을 닫으시려면 아무키나 누르세요...");
            ReadKey();
        }
    }
    class Exception
    {
        public Exception()
        {
            int[] arr = { 1, 2, 3 };
            
            for(int i = 0; i < 5; i++)
            {
                WriteLine(arr[i]);      // 배열의 크기를 넘어서면 예외를 발생시키며 프로그램이 종료됨.
            }

            WriteLine("종료");          // 따라서 이 코드는 실행되지 않음
        }
    }                   // 1. 예외 상황 
    class TryCatch
    { 
        public TryCatch()
        {
            int[] arr = { 1, 2, 3 };

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    WriteLine(arr[i]);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                WriteLine($"예외가 발생했습니다 : {e.Message}");
            }

            WriteLine("종료");
        }
    }                    // 2. TryCatch문
    class Throw
    {
        static void DoSomething(int arg)
        {
            if (arg < 10)
                WriteLine($"arg : {arg}");
            else
                throw new System.Exception("arg가 10보다 큽니다.");
        }

        public Throw()
        {
            try
            {
                DoSomething(1);
                DoSomething(3);
                DoSomething(5);
                DoSomething(9);
                DoSomething(11);
                DoSomething(13);
            }
            catch(System.Exception e)
            {
                WriteLine(e.Message);
            }
        }
    }                       // 3. Throw문
    class ThrowException
    {
        public ThrowException()
        {
            try
            {
                int? a = null;
                int b = a ?? throw new ArgumentNullException();
            }
            catch(ArgumentNullException e)
            {
                WriteLine(e);
            }

            try
            {
                int[] array = { 1, 2, 3 };
                int index = 4;
                int value = array[index >= 0 && index < 3 ? index : throw new IndexOutOfRangeException()];
            }
            catch(IndexOutOfRangeException e)
            {
                WriteLine(e);
            }
        }
    }              // 4. 예외 던지기
    class Finally
    {
        public Finally()
        {
            try
            {
                Write("제수를 입력하세요 : ");
                int dividend = Int32.Parse(ReadLine());

                Write("피제수를 입력하세요 : ");
                int divisor = Int32.Parse(ReadLine());

                WriteLine("{0} / {1} = {2}", dividend, divisor, Divide(dividend, divisor));
            }
            catch (FormatException e)
            {
                WriteLine("에러 : " + e.Message);
            }
            catch (DivideByZeroException e)
            {
                WriteLine("에러 : " + e.Message);
            }
            finally
            {
                WriteLine("Finally문 작동");
            }
        }

        static int Divide(int dividend,int divisor)
        {
            try
            {
                WriteLine("Divied() 시작");
                return dividend / divisor;
            }
            catch(DivideByZeroException e)
            {
                WriteLine("Divide() 예외 발생");
                throw e;
            }
            finally
            {
                WriteLine("Divide() 끝");
            }
        }
    }                     // 5. Finally문
    class MyException
    {
        public MyException()
        {
            try
            {
                WriteLine("0x{0:X}", MergeARGB(255, 111, 111, 111));
                WriteLine("0x{0:X}", MergeARGB(1, 65, 192, 128));
                WriteLine("0x{0:X}", MergeARGB(0, 255, 255, 300));
            }
            catch(InvalidArgumentException e)
            {
                WriteLine(e.Message);
                WriteLine($"Argument:{e.Argument}, Range:{e.Range}");
            }
        }

        class InvalidArgumentException : System.Exception
        {
            public InvalidArgumentException()
            {

            }

            public InvalidArgumentException(string message) : base(message) { }

            public object Argument { get; set; }
            public string Range { get; set; }
        }

        static uint MergeARGB(uint alpha, uint red, uint green, uint blue)
        {
            uint[] args = new uint[] { alpha, red, green, blue };

            foreach(uint arg in args)
            {
                if (arg > 255)
                    throw new InvalidArgumentException()
                    {
                        Argument = arg,
                        Range = "0~255"
                    };
            }

            return (alpha << 24 & 0xFF000000) |
                   (red << 16 & 0x00FF0000) |
                   (green << 8 & 0x0000FF00) |
                   (blue & 0x000000FF);
        }
    }                 // 6. 사용자 정의 예외
    class ExceptionFiltering
    {
        public ExceptionFiltering()
        {
            WriteLine("Enter Number Between 0~10");
            try
            {
                int num = Int32.Parse(ReadLine());

                if (num < 0 || num > 10)
                    throw new FilterableException() { ErrorNo = num };
                else
                    WriteLine($"Output : {num}");
            }
            catch(FilterableException e) when (e.ErrorNo < 0)
            {
                WriteLine("Negative input is not allowed.");
            }
            catch(FilterableException e) when (e.ErrorNo > 10)
            {
                WriteLine("Too big number is not allowed.");
            }
        }

        class FilterableException : System.Exception
        {
            public int ErrorNo { get; set; }
        }
    }          // 7. 예외 필터
    class StackTrace
    {
        public StackTrace()
        {
            try
            {
                int a = 1;
                WriteLine(3 / --a);
            }
            catch(DivideByZeroException e)
            {
                WriteLine(e.StackTrace);
            }
        }
    }                  // 8. StackTrace
}
