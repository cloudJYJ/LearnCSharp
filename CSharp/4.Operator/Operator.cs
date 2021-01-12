using System;
using static System.Console;
using System.Collections;

namespace _4.Operator
{
    class Operator
    {
        static void Main(string[] args)
        {
            WriteLine("[ 1 ] 산술 연산자");
            WriteLine("[ 2 ] 증감 연산자");
            WriteLine("[ 3 ] 문자열 결합 연산자");
            WriteLine("[ 4 ] 관계 연산자");
            WriteLine("[ 5 ] 논리 연산자");
            WriteLine("[ 6 ] 조건 연산자");
            WriteLine("[ 7 ] 널 조건부 연산자");
            WriteLine("[ 8 ] 시프트 연산자");
            WriteLine("[ 9 ] 비트 논리 연산자");
            WriteLine("[10 ] 할당 연산자");
            WriteLine("[11 ] Null 병합 연산자");
            string choice = ReadLine();
            if(choice == "1") { ArithmaticOperators ArithmaticOperatiors = new ArithmaticOperators(); }
            if(choice == "2") { IncDecOperator IncDecOperator = new IncDecOperator(); }
            if(choice == "3") { StringConcatenate StringConcatenate = new StringConcatenate(); }
            if(choice == "4") { RelationalOperator RelationalOperator = new RelationalOperator(); }
            if(choice == "5") { LogicalOperator LogicalOperator = new LogicalOperator(); }
            if(choice == "6") { ConditionalOperator ConditionalOperator = new ConditionalOperator(); }
            if(choice == "7") { NullConditionalOperator NullConditionalOperator = new NullConditionalOperator(); }
            if(choice == "8") { ShiftOperator ShiftOperator = new ShiftOperator(); }
            if(choice == "9") { BitwiseOperator BitwiseOperator = new BitwiseOperator(); }
            if(choice == "10") { AssignmentOperator AssingmentOperator = new AssignmentOperator(); }
            if(choice == "11") { NullCoalescing NullCoalescing = new NullCoalescing(); }
        }
    }

    class ArithmaticOperators
    {
        public ArithmaticOperators()
        {
            int a = 111 + 222;
            WriteLine($"a : {a}");

            int b = -100;
            WriteLine($"b : {b}");
           
            int c = b * 10;
            WriteLine($"c : {c}");
        
            double d = c / 6.3;
            WriteLine($"d : {d}");
            WriteLine($"22 / 7 == {22 / 7}({22 % 7})");

        }
    }          // 1. 산술 연산자
    class IncDecOperator
    {
        public IncDecOperator()
        {
            int a = 10;
            WriteLine(a++);
            WriteLine(++a);

            WriteLine(a--);
            WriteLine(--a);
        }
    }               // 2. 증감 연산자    
    class StringConcatenate
    {
        public StringConcatenate()
        {
            string result = "123" + "456";
            WriteLine(result);

            result = "Hello" + " " + "World!";
            WriteLine(result);
        }
    }            // 3. 문자열 결합 연산자
    class RelationalOperator
    {
        public RelationalOperator()
        {
            WriteLine($"3 > 4 : {3 > 4}");
            WriteLine($"3 >= 4 : {3 >= 4}");
            WriteLine($"3 < 4 : {3 < 4}");
            WriteLine($"3 <= 4 : {3 <= 4}");
            WriteLine($"3 == 4 : {3 == 4}");
            WriteLine($"3 != 4 : {3 != 4}");
        }
    }           // 4. 관계 연산자
    class LogicalOperator
    {
        public LogicalOperator()
        {
            WriteLine("Testing && ... ");
            WriteLine($"1 > 0 && 4 < 5 : {1 > 0 && 4 < 5}");
            WriteLine($"1 > 0 && 4 > 5 : {1 > 0 && 4 > 5}");
            WriteLine($"1 == 0 && 4 > 5 : {1 == 0 && 4 > 5}");
            WriteLine($"1 == 0 && 4 < 5 : {1 == 0 && 4 < 5}");

            WriteLine("\nTesting || ...");
            WriteLine($"1 > 0 || 4 < 5 : {1 > 0 || 4 < 5}");
            WriteLine($"1 > 0 || 4 > 5 : {1 > 0 || 4 > 5}");
            WriteLine($"1 == 0 || 4 > 5 : {1 == 0 || 4 > 5}");
            WriteLine($"1 == 0 || 4 < 5 : {1 == 0 || 4 < 5}");

            WriteLine("\nTesting ! ...");
            WriteLine($"!True : {!true}");
            WriteLine($"!False : {!false}");
        }
    }              // 5. 논리 연산자
    class ConditionalOperator
    {
        public ConditionalOperator()
        {
            string result = (10 % 2) == 0 ? "짝수" : "홀수";

            WriteLine(result);
        }
    }          // 6. 조건 연산자
    class NullConditionalOperator
    {
        public NullConditionalOperator()
        {
            ArrayList a = null;
            a?.Add("야구"); // a?.이 null을 반환하므로 Add() 메소드는 호출되지 않음
            a?.Add("축구");
            WriteLine($"Count : {a?.Count}");
            WriteLine($"{a?[0]}");
            WriteLine($"{a?[1]}");

            a = new ArrayList(); // a는 이제 더 이상 null이 아닙니다.
            a?.Add("야구");
            a?.Add("축구");
            WriteLine($"Count : {a?.Count}");
            WriteLine($"{a?[0]}");
            WriteLine($"{a?[1]}");
        }
    }      // 7. 널 조건부 연산자
    class ShiftOperator
    {
        public ShiftOperator()
        {
            WriteLine("Testing <<...");

            int a = 1;
            WriteLine("a      : {0:D5} (0x{0:X8})", a);
            WriteLine("a << 1 : {0:D5} (0x{0:X8})", a << 1);
            WriteLine("a << 2 : {0:D5} (0x{0:X8})", a << 2);
            WriteLine("a << 5 : {0:D5} (0x{0:X8})", a << 5);

            WriteLine("\nTesting >>...");

            int b = 255;
            WriteLine("b      : {0:D5} (0x{0:X8})", b);
            WriteLine("b >> 1 : {0:D5} (0x{0:X8})", b >> 1);
            WriteLine("b >> 2 : {0:D5} (0x{0:X8})", b >> 2);
            WriteLine("b >> 5 : {0:D5} (0x{0:X8})", b >> 5);
        }
    }                // 8. 시프트 연산자
    class BitwiseOperator
    {
        public BitwiseOperator()
        {
            int a = 9;
            int b = 10;

            WriteLine($"{a} & {b} : {a & b}");
            WriteLine($"{a} | {b} : {a | b}");
            WriteLine($"{a} ^ {b} : {a ^ b}");

            int c = 255;
            WriteLine("~{0}(0x{0:X8}) : {1}(0x{1:X8})", c, ~c);
        }
    }              // 9. 비트 논리 연산자
    class AssignmentOperator
    {
        public AssignmentOperator()
        {
            int a;
            a = 100;
            WriteLine($"a = 100 : {a}");
            a += 90;
            WriteLine($"a += 90 : {a}");
            a -= 80;
            WriteLine($"a -= 80 : {a}");
            a *= 70;
            WriteLine($"a *= 70 : {a}");
            a /= 60;
            WriteLine($"a /= 60 : {a}");
            a %= 50;
            WriteLine($"a %= 50 : {a}");
            a &= 40;
            WriteLine($"a &= 40 : {a}");
            a |= 30;
            WriteLine($"a |= 30 : {a}");
            a ^= 20;
            WriteLine($"a ^= 20 : {a}");
            a <<= 10;
            WriteLine($"a <<= 10 : {a}");
            a >>= 1;
            WriteLine($"a >>= 1 : {a}");
        }
    }           // 10. 할당 연산자
    class NullCoalescing
    {
        public NullCoalescing()
        {
            int? num = null;
            WriteLine($"{num ?? 0}");

            num = 99;
            WriteLine($"{num ?? 0}");

            string str = null;
            WriteLine($"{str ?? "Default"}");

            str = "Specific";
            WriteLine($"{str ?? "Default"}");

        }
    }               // 11. Null 병합 연산자

}
